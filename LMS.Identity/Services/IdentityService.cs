using LMS.Application.Interfaces;
using LMS.Identity.Models;
using LMS.Shared.DTOs.Auth;
using LMS.Shared.Responses;
using Microsoft.AspNetCore.Identity;

namespace LMS.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly JwtTokenService _jwtTokenService;


    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<ApplicationRole> roleManager,
        JwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwtTokenService = jwtTokenService;
    }



    public async Task<ApiResponse<LoginResponseDto>> LoginAsync(
        LoginRequestDto request)
    {
        var user = await _userManager
            .FindByEmailAsync(request.Email);


        if (user == null)
        {
            return ApiResponse<LoginResponseDto>
                .Fail("Invalid email or password");
        }


        var result =
            await _signInManager
            .CheckPasswordSignInAsync(
                user,
                request.Password,
                false);


        if (!result.Succeeded)
        {
            return ApiResponse<LoginResponseDto>
                .Fail("Invalid email or password");
        }


        var roles =
            await _userManager
            .GetRolesAsync(user);


        var token =
            _jwtTokenService
            .GenerateToken(user, roles);



        var response =
            new LoginResponseDto
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email ?? "",
                Roles = roles.ToList()
            };


        return ApiResponse<LoginResponseDto>
            .Success(
                response,
                "Login successful");
    }



  public async Task<ApiResponse<bool>> RegisterAsync(
    RegisterRequestDto request)
{
    // Check if email already exists
    var existingUser = await _userManager.FindByEmailAsync(request.Email);

    if (existingUser != null)
    {
        return ApiResponse<bool>.Fail("Email address already exists.");
    }

    // Create user
    var user = new ApplicationUser
    {
        UserName = request.Email,
        Email = request.Email,
        FirstName = request.FirstName,
        LastName = request.LastName,
        EmailConfirmed = true,
        IsActive = true
    };

    // Create Identity user
    var result = await _userManager.CreateAsync(user, request.Password);

    if (!result.Succeeded)
    {
        return ApiResponse<bool>.Fail(
            string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    // Assign default role
    if (await _roleManager.RoleExistsAsync("Student"))
    {
        await _userManager.AddToRoleAsync(user, "Student");
    }

    return ApiResponse<bool>.Success(true, "Registration successful.");
}


public async Task<ApiResponse<bool>> ChangePasswordAsync(
    ChangePasswordDto request)
{
    var user = await _userManager.FindByIdAsync(request.UserId);

    if (user == null)
    {
        return ApiResponse<bool>.Fail("User not found.");
    }

    var result = await _userManager.ChangePasswordAsync(
        user,
        request.CurrentPassword,
        request.NewPassword);

    if (!result.Succeeded)
    {
        return ApiResponse<bool>.Fail(
            string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    return ApiResponse<bool>.Success(
        true,
        "Password changed successfully.");
}

public async Task<ApiResponse<ForgotPasswordResponseDto>> ForgotPasswordAsync(
    ForgotPasswordDto request)
{
    var user = await _userManager.FindByEmailAsync(request.Email);

    if (user == null)
    {
        return ApiResponse<ForgotPasswordResponseDto>.Fail(
            "User not found.");
    }

    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

    var response = new ForgotPasswordResponseDto
    {
        EmailSent = false,
        ResetToken = token
    };

    return ApiResponse<ForgotPasswordResponseDto>.Success(
        response,
        "Password reset token generated successfully.");
}


    public Task<ApiResponse<bool>> ResetPasswordAsync(
        ResetPasswordDto request)
    {
        throw new NotImplementedException();
    }



    public Task<ApiResponse<CurrentUserDto>> GetCurrentUserAsync(
        string userId)
    {
        throw new NotImplementedException();
    }
}
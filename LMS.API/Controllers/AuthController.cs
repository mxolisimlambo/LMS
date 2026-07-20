using LMS.Application.Interfaces;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;
[Authorize(Policy = PermissionConstants.Users.Create)]
[ApiExplorerSettings(GroupName = "identity")]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public AuthController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    // ============================================
    // REGISTER
    // ============================================

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterRequestDto model)
    {
        var result = await _identityService.RegisterAsync(model);

        if (!result.success)
            return BadRequest(result);

        return Ok(result);
    }

    // ============================================
    // LOGIN
    // ============================================

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequestDto model)
    {
        var result = await _identityService.LoginAsync(model);

        if (!result.success)
            return Unauthorized(result);

        return Ok(result);
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(
    ChangePasswordDto request)
    {
        var response = await _identityService.ChangePasswordAsync(request);

        if (!response.success)
            return BadRequest(response);

        return Ok(response);
    }
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(
    ForgotPasswordDto request)
    {
        var response =
            await _identityService.ForgotPasswordAsync(request);

        if (!response.success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(
        ResetPasswordDto request)
    {
        var result = await _identityService.ResetPasswordAsync(request);

        return Ok(result);
    }
    [HttpGet("current-user/{userId}")]
    public async Task<IActionResult> GetCurrentUser(string userId)
    {
        var result = await _identityService.GetCurrentUserAsync(userId);

        return Ok(result);
    }
}

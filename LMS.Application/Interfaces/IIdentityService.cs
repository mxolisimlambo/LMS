using LMS.Shared.DTOs.Auth;
using LMS.Shared.DTOs.Roles;
using LMS.Shared.Responses;
namespace LMS.Application.Interfaces;

public interface IIdentityService
{
    Task<ApiResponse<LoginResponseDto>> LoginAsync(
        LoginRequestDto request);

    Task<ApiResponse<bool>> RegisterAsync(
        RegisterRequestDto request);

    Task<ApiResponse<bool>> ChangePasswordAsync(
        ChangePasswordDto request);

    Task<ApiResponse<ForgotPasswordResponseDto>> ForgotPasswordAsync(
     ForgotPasswordDto request);

    Task<ApiResponse<bool>> ResetPasswordAsync(
        ResetPasswordDto request);

    Task<ApiResponse<CurrentUserDto>> GetCurrentUserAsync(
        string userId);

}

using LMS.Shared.DTOs.Auth;
using LMS.Shared.Responses;
using LMS.Shared.DTOs.Roles;
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

        Task<List<RoleDto>> GetRolesAsync();

Task<RoleDto?> GetRoleByIdAsync(string id);

Task<bool> CreateRoleAsync(CreateRoleDto dto);

Task<bool> UpdateRoleAsync(UpdateRoleDto dto);

Task<bool> DeleteRoleAsync(string id);
}
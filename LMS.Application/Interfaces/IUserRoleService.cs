using LMS.Shared.DTOs.Roles;

namespace LMS.Application.Interfaces;

public interface IUserRoleService
{
    Task<bool> AssignRoleToUserAsync(AssignRoleDto dto);

    Task<bool> RemoveRoleFromUserAsync(AssignRoleDto dto);

    Task<List<string>> GetUserRolesAsync(string userId);

    Task<List<UserRoleDto>> GetUsersInRoleAsync(string roleName);
}

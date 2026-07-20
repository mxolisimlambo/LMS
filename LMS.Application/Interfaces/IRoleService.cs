using LMS.Shared.DTOs.Roles;

namespace LMS.Application.Interfaces;

public interface IRoleService
{
    Task<List<RoleDto>> GetRolesAsync();

    Task<RoleDto?> GetRoleByIdAsync(string id);

    Task<bool> CreateRoleAsync(CreateRoleDto dto);

    Task<bool> UpdateRoleAsync(UpdateRoleDto dto);

    Task<bool> DeleteRoleAsync(string id);
}

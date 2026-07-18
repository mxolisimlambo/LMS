using LMS.Shared.DTOs.Permissions;

namespace LMS.Application.Interfaces;

public interface IPermissionService
{
    Task<List<PermissionDto>> GetPermissionsAsync();

    Task<PermissionDto?> GetPermissionByIdAsync(int id);

    Task<List<PermissionDto>> GetPermissionsByModuleAsync(string module);

    Task<bool> CreatePermissionAsync(PermissionDto dto);

    Task<bool> UpdatePermissionAsync(PermissionDto dto);

    Task<bool> DeletePermissionAsync(int id);

    Task<bool> AssignPermissionToRoleAsync(AssignPermissionDto dto);

    Task<List<PermissionDto>> GetRolePermissionsAsync(string roleId);
}
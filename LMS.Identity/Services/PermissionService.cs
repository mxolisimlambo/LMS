using LMS.Application.Interfaces;
using LMS.Identity.Data;
using LMS.Identity.Models;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Permissions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS.Identity.Services;

public class PermissionService : IPermissionService
{
    private readonly ApplicationIdentityDbContext _context;

    private readonly RoleManager<ApplicationRole> _roleManager;

    public PermissionService(
        ApplicationIdentityDbContext context,
        RoleManager<ApplicationRole> roleManager)
    {
        _context = context;
        _roleManager = roleManager;
    }
    public async Task<List<PermissionDto>> GetPermissionsAsync()
    {
        return await _context.Permissions
            .OrderBy(x => x.Module)
            .ThenBy(x => x.DisplayName)
            .Select(x => new PermissionDto
            {
                Id = x.Id,
                Name = x.Name,
                DisplayName = x.DisplayName,
                Description = x.Description,
                Module = x.Module,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }
    public async Task<PermissionDto?> GetPermissionByIdAsync(int id)
    {
        return await _context.Permissions
            .Where(x => x.Id == id)
            .Select(x => new PermissionDto
            {
                Id = x.Id,
                Name = x.Name,
                DisplayName = x.DisplayName,
                Description = x.Description,
                Module = x.Module,
                IsActive = x.IsActive
            })
            .FirstOrDefaultAsync();
    }
    public async Task<List<PermissionDto>> GetPermissionsByModuleAsync(string module)
    {
        return await _context.Permissions
            .Where(x => x.Module == module)
            .OrderBy(x => x.DisplayName)
            .Select(x => new PermissionDto
            {
                Id = x.Id,
                Name = x.Name,
                DisplayName = x.DisplayName,
                Description = x.Description,
                Module = x.Module,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }
    public async Task<bool> CreatePermissionAsync(PermissionDto dto)
    {
        if (await _context.Permissions.AnyAsync(x => x.Name == dto.Name))
            return false;

        var permission = new Permission
        {
            Name = dto.Name,
            DisplayName = dto.DisplayName,
            Description = dto.Description,
            Module = dto.Module,
            IsActive = dto.IsActive
        };

        _context.Permissions.Add(permission);

        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> UpdatePermissionAsync(PermissionDto dto)
    {
        var permission = await _context.Permissions.FindAsync(dto.Id);

        if (permission == null)
            return false;

        permission.Name = dto.Name;
        permission.DisplayName = dto.DisplayName;
        permission.Description = dto.Description;
        permission.Module = dto.Module;
        permission.IsActive = dto.IsActive;

        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeletePermissionAsync(int id)
    {
        var permission = await _context.Permissions.FindAsync(id);

        if (permission == null)
            return false;

        _context.Permissions.Remove(permission);

        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> AssignPermissionToRoleAsync(
        AssignPermissionDto dto)
    {
        var role = await _roleManager.FindByIdAsync(dto.RoleId);

        if (role == null)
            return false;

        var permission = await _context.Permissions
            .FindAsync(dto.PermissionId);

        if (permission == null)
            return false;

        var exists = await _context.RolePermissions.AnyAsync(x =>
            x.RoleId == dto.RoleId &&
            x.PermissionId == dto.PermissionId);

        if (exists)
            return true;

        _context.RolePermissions.Add(new RolePermission
        {
            RoleId = dto.RoleId,
            PermissionId = dto.PermissionId
        });

        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<List<PermissionDto>> GetRolePermissionsAsync(
        string roleId)
    {
        return await _context.RolePermissions
            .Where(x => x.RoleId == roleId)
            .Include(x => x.Permission)
            .Select(x => new PermissionDto
            {
                Id = x.Permission!.Id,
                Name = x.Permission.Name,
                DisplayName = x.Permission.DisplayName,
                Description = x.Permission.Description,
                Module = x.Permission.Module,
                IsActive = x.Permission.IsActive
            })
            .ToListAsync();
    }

}
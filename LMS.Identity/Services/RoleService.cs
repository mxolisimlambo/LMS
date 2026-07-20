using LMS.Application.Interfaces;
using LMS.Identity.Models;
using LMS.Shared.DTOs.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS.Identity.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public RoleService(
        RoleManager<ApplicationRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<List<RoleDto>> GetRolesAsync()
    {
        return await _roleManager.Roles
            .Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name!,
                Description = r.Description,
                IsActive = r.IsActive
            })
            .ToListAsync();
    }

    public async Task<RoleDto?> GetRoleByIdAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);

        if (role == null)
            return null;

        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name!,
            Description = role.Description,
            IsActive = role.IsActive
        };
    }

    public async Task<bool> CreateRoleAsync(CreateRoleDto dto)
    {
        if (await _roleManager.RoleExistsAsync(dto.Name))
            return false;

        var role = new ApplicationRole
        {
            Name = dto.Name,
            Description = dto.Description ?? string.Empty,
            IsActive = true
        };

        var result = await _roleManager.CreateAsync(role);

        return result.Succeeded;
    }

    public async Task<bool> UpdateRoleAsync(UpdateRoleDto dto)
    {
        var role = await _roleManager.FindByIdAsync(dto.Id);

        if (role == null)
            return false;

        role.Name = dto.Name;
        role.Description = dto.Description ?? string.Empty;
        role.IsActive = dto.IsActive;

        var result = await _roleManager.UpdateAsync(role);

        return result.Succeeded;
    }

    public async Task<bool> DeleteRoleAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);

        if (role == null)
            return false;

        var result = await _roleManager.DeleteAsync(role);

        return result.Succeeded;
    }
}

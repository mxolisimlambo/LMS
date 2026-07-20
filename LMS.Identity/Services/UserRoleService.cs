using LMS.Application.Interfaces;
using LMS.Identity.Models;
using LMS.Shared.DTOs.Roles;
using Microsoft.AspNetCore.Identity;

namespace LMS.Identity.Services;

public class UserRoleService : IUserRoleService
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly RoleManager<ApplicationRole> _roleManager;

    public UserRoleService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<bool> AssignRoleToUserAsync(
    AssignRoleDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId);

        if (user == null)
            return false;

        if (!await _roleManager.RoleExistsAsync(dto.RoleName))
            return false;

        if (await _userManager.IsInRoleAsync(user, dto.RoleName))
            return true;

        var result = await _userManager.AddToRoleAsync(
            user,
            dto.RoleName);

        return result.Succeeded;
    }
    public async Task<bool> RemoveRoleFromUserAsync(
        AssignRoleDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId);

        if (user == null)
            return false;

        if (!await _userManager.IsInRoleAsync(user, dto.RoleName))
            return false;

        var result = await _userManager.RemoveFromRoleAsync(
            user,
            dto.RoleName);

        return result.Succeeded;
    }
    public async Task<List<string>> GetUserRolesAsync(
        string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return new List<string>();

        return (await _userManager.GetRolesAsync(user)).ToList();
    }
    public async Task<List<UserRoleDto>> GetUsersInRoleAsync(
        string roleName)
    {
        var users = await _userManager.GetUsersInRoleAsync(roleName);

        return users
            .Select(x => new UserRoleDto
            {
                UserId = x.Id,
                FullName = $"{x.FirstName} {x.LastName}".Trim(),
                Email = x.Email ?? string.Empty,
                IsActive = x.IsActive
            })
            .ToList();
    }
}
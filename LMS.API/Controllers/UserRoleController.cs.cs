using LMS.Application.Interfaces;
using LMS.Shared.DTOs.Roles;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleService _userRoleService;

    public UserRoleController(
        IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    //=========================================
    // Assign Role
    //=========================================

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole(
        AssignRoleDto dto)
    {
        var result =
            await _userRoleService.AssignRoleToUserAsync(dto);

        return Ok(result);
    }

    //=========================================
    // Remove Role
    //=========================================

    [HttpPost("remove")]
    public async Task<IActionResult> RemoveRole(
        AssignRoleDto dto)
    {
        var result =
            await _userRoleService.RemoveRoleFromUserAsync(dto);

        return Ok(result);
    }

    //=========================================
    // Get User Roles
    //=========================================

    [HttpGet("{userId}/roles")]
    public async Task<IActionResult> GetUserRoles(
        string userId)
    {
        var result =
            await _userRoleService.GetUserRolesAsync(userId);

        return Ok(result);
    }

    //=========================================
    // Get Users In Role
    //=========================================

    [HttpGet("role/{roleName}")]
    public async Task<IActionResult> GetUsersInRole(
        string roleName)
    {
        var result =
            await _userRoleService.GetUsersInRoleAsync(roleName);

        return Ok(result);
    }
}
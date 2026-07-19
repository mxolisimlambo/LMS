using LMS.Application.Interfaces;
using LMS.Shared.DTOs.Roles;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "students")]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _roleService.GetRolesAsync();

        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);

        if (role == null)
            return NotFound();

        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleDto dto)
    {
        var result = await _roleService.CreateRoleAsync(dto);

        if (!result)
            return BadRequest("Role already exists.");

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRoleDto dto)
    {
        var result = await _roleService.UpdateRoleAsync(dto);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _roleService.DeleteRoleAsync(id);

        if (!result)
            return BadRequest();

        return Ok(result);
    }
}
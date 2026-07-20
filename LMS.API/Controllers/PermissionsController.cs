using LMS.Application.Interfaces;
using LMS.Shared.DTOs.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Permissions;

[ApiController]
[ApiExplorerSettings(GroupName = "students")]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionController(
        IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _permissionService.GetPermissionsAsync();

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result =
            await _permissionService.GetPermissionByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("module/{module}")]
    public async Task<IActionResult> GetByModule(string module)
    {
        var result =
            await _permissionService.GetPermissionsByModuleAsync(module);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        PermissionDto dto)
    {
        var result =
            await _permissionService.CreatePermissionAsync(dto);

        if (!result)
            return BadRequest("Permission already exists.");

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        PermissionDto dto)
    {
        var result =
            await _permissionService.UpdatePermissionAsync(dto);

        if (!result)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _permissionService.DeletePermissionAsync(id);

        if (!result)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignPermission(
        AssignPermissionDto dto)
    {
        var result =
            await _permissionService.AssignPermissionToRoleAsync(dto);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpGet("role/{roleId}")]
    public async Task<IActionResult> GetRolePermissions(
        string roleId)
    {
        var result =
            await _permissionService.GetRolePermissionsAsync(roleId);

        return Ok(result);
    }
}

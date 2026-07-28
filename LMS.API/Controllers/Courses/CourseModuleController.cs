using LMS.Application.Interfaces.Courses;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Courses.Module;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "coursemodul")]
[Route("api/[controller]")]
//[Authorize]
public class CourseModuleController : ControllerBase
{
    private readonly ICourseModuleService _courseModuleService;

    public CourseModuleController(
        ICourseModuleService courseModuleService)
    {
        _courseModuleService = courseModuleService;
    }

    // ==========================================
    // GET MODULE BY ID
    // ==========================================

    [HttpGet("{courseModuleId:long}")]
    [Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetModuleById(
        long courseModuleId)
    {
        var module = await _courseModuleService
            .GetModuleByIdAsync(courseModuleId);

        if (module == null)
            return NotFound();

        return Ok(module);
    }

    // ==========================================
    // GET MODULES BY COURSE
    // ==========================================

    [HttpGet("course/{courseId:long}")]
    [Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetModulesByCourse(
        long courseId)
    {
        var modules = await _courseModuleService
            .GetModulesByCourseAsync(courseId);

        return Ok(modules);
    }

    // ==========================================
    // CREATE MODULE
    // ==========================================

    [HttpPost]
    //[Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateModule(
        CreateCourseModuleDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _courseModuleService
            .CreateModuleAsync(dto);

        if (!created)
            return BadRequest("Unable to create module.");

        return Ok(new
        {
            Message = "Course module created successfully."
        });
    }

    // ==========================================
    // UPDATE MODULE
    // ==========================================

    [HttpPut]
    //  [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateModule(
        UpdateCourseModuleDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _courseModuleService
            .UpdateModuleAsync(dto);

        if (!updated)
            return NotFound();

        return Ok(new
        {
            Message = "Course module updated successfully."
        });
    }

    // ==========================================
    // DELETE MODULE
    // ==========================================

    [HttpDelete("{courseModuleId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteModule(
        long courseModuleId)
    {
        var deleted = await _courseModuleService
            .DeleteModuleAsync(courseModuleId);

        if (!deleted)
            return NotFound();

        return Ok(new
        {
            Message = "Course module deleted successfully."
        });
    }

    // ==========================================
    // REORDER MODULES
    // ==========================================

    [HttpPut("reorder/{courseId:long}")]
    // [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> ReOrderModules(
        long courseId,
        [FromBody] List<long> moduleIds)
    {
        var reordered = await _courseModuleService
            .ReOrderModulesAsync(
                courseId,
                moduleIds);

        if (!reordered)
            return NotFound();

        return Ok(new
        {
            Message = "Course modules reordered successfully."
        });
    }
}

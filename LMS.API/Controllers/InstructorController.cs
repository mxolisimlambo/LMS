using LMS.Application.Interfaces;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Instructors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "instructors")]
[Route("api/[controller]")]
//[Authorize]
public class InstructorController : ControllerBase
{
    private readonly IInstructorService _instructorService;

    public InstructorController(
        IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }

    // ==========================================
    // GET INSTRUCTOR BY ID
    // ==========================================

    [HttpGet("{instructorProfileId:long}")]
    [Authorize(Policy = PermissionConstants.Instructors.View)]
    public async Task<IActionResult> GetInstructorById(
        long instructorProfileId)
    {
        var instructor = await _instructorService
            .GetInstructorByIdAsync(instructorProfileId);

        if (instructor == null)
            return NotFound();

        return Ok(instructor);
    }

    // ==========================================
    // GET INSTRUCTOR BY USER ID
    // ==========================================

    [HttpGet("user/{userId}")]
    [Authorize(Policy = PermissionConstants.Instructors.View)]
    public async Task<IActionResult> GetInstructorByUserId(
        string userId)
    {
        var instructor = await _instructorService
            .GetInstructorByUserIdAsync(userId);

        if (instructor == null)
            return NotFound();

        return Ok(instructor);
    }

    // ==========================================
    // GET ALL INSTRUCTORS
    // ==========================================

    [HttpGet]
    //[Authorize(Policy = PermissionConstants.Instructors.View)]
    public async Task<IActionResult> GetAllInstructors()
    {
        var instructors = await _instructorService
            .GetAllInstructorsAsync();

        return Ok(instructors);
    }

    // ==========================================
    // CREATE INSTRUCTOR PROFILE
    // ==========================================

    [HttpPost]
   // [Authorize(Policy = PermissionConstants.Instructors.Create)]
    public async Task<IActionResult> CreateInstructor(
        CreateInstructorProfileDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _instructorService
            .CreateInstructorProfileAsync(dto);

        if (!created)
            return BadRequest("Instructor profile already exists.");

        return Ok(new
        {
            Message = "Instructor profile created successfully."
        });
    }

    // ==========================================
    // UPDATE INSTRUCTOR PROFILE
    // ==========================================

    [HttpPut]
    [Authorize(Policy = PermissionConstants.Instructors.Update)]
    public async Task<IActionResult> UpdateInstructor(
        UpdateInstructorProfileDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _instructorService
            .UpdateInstructorProfileAsync(dto);

        if (!updated)
            return NotFound();

        return Ok(new
        {
            Message = "Instructor profile updated successfully."
        });
    }

    // ==========================================
    // DELETE INSTRUCTOR
    // ==========================================

    [HttpDelete("{instructorProfileId:long}")]
    [Authorize(Policy = PermissionConstants.Instructors.Delete)]
    public async Task<IActionResult> DeleteInstructor(
        long instructorProfileId)
    {
        var deleted = await _instructorService
            .DeleteInstructorProfileAsync(instructorProfileId);

        if (!deleted)
            return NotFound();

        return Ok(new
        {
            Message = "Instructor profile deleted successfully."
        });
    }

    // ==========================================
    // ACTIVATE INSTRUCTOR
    // ==========================================

    [HttpPut("activate/{instructorProfileId:long}")]
    [Authorize(Policy = PermissionConstants.Instructors.Update)]
    public async Task<IActionResult> ActivateInstructor(
        long instructorProfileId)
    {
        var activated = await _instructorService
            .ActivateInstructorAsync(instructorProfileId);

        if (!activated)
            return NotFound();

        return Ok(new
        {
            Message = "Instructor activated successfully."
        });
    }

    // ==========================================
    // DEACTIVATE INSTRUCTOR
    // ==========================================

    [HttpPut("deactivate/{instructorProfileId:long}")]
    [Authorize(Policy = PermissionConstants.Instructors.Update)]
    public async Task<IActionResult> DeactivateInstructor(
        long instructorProfileId)
    {
        var deactivated = await _instructorService
            .DeactivateInstructorAsync(instructorProfileId);

        if (!deactivated)
            return NotFound();

        return Ok(new
        {
            Message = "Instructor deactivated successfully."
        });
    }
}
using LMS.Application.Interfaces;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "students")]
[Route("api/[controller]")]
//[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(
        IStudentService studentService)
    {
        _studentService = studentService;
    }

    // ==========================================
    // GET STUDENT BY ID
    // ==========================================

    [HttpGet("{studentProfileId:long}")]
    [Authorize(Policy = PermissionConstants.Students.View)]
    public async Task<IActionResult> GetStudentById(
        long studentProfileId)
    {
        var student = await _studentService
            .GetStudentByIdAsync(studentProfileId);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    // ==========================================
    // GET STUDENT BY USER ID
    // ==========================================

    [HttpGet("user/{userId}")]
    //[Authorize(Policy = PermissionConstants.Students.View)]
    public async Task<IActionResult> GetStudentByUserId(
        string userId)
    {
        var student = await _studentService
            .GetStudentByUserIdAsync(userId);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    // ==========================================
    // GET ALL STUDENTS
    // ==========================================

    [HttpGet]
    [Authorize(Policy = PermissionConstants.Students.View)]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService
            .GetAllStudentsAsync();

        return Ok(students);
    }

    // ==========================================
    // CREATE STUDENT PROFILE
    // ==========================================

    [HttpPost]
    //[Authorize(Policy = PermissionConstants.Students.Create)]
    public async Task<IActionResult> CreateStudent(
        CreateStudentProfileDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _studentService
            .CreateStudentProfileAsync(dto);

        if (!created)
            return BadRequest("Student profile already exists.");

        return Ok(new
        {
            Message = "Student profile created successfully."
        });
    }

    // ==========================================
    // UPDATE STUDENT PROFILE
    // ==========================================

    [HttpPut]
    [Authorize(Policy = PermissionConstants.Students.Update)]
    public async Task<IActionResult> UpdateStudent(
        UpdateStudentProfileDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _studentService
            .UpdateStudentProfileAsync(dto);

        if (!updated)
            return NotFound();

        return Ok(new
        {
            Message = "Student profile updated successfully."
        });
    }

    // ==========================================
    // DELETE STUDENT (SOFT DELETE)
    // ==========================================

    [HttpDelete("{studentProfileId:long}")]
    [Authorize(Policy = PermissionConstants.Students.Delete)]
    public async Task<IActionResult> DeleteStudent(
        long studentProfileId)
    {
        var deleted = await _studentService
            .DeleteStudentProfileAsync(studentProfileId);

        if (!deleted)
            return NotFound();

        return Ok(new
        {
            Message = "Student profile deleted successfully."
        });
    }

    // ==========================================
    // ACTIVATE STUDENT
    // ==========================================

    [HttpPut("activate/{studentProfileId:long}")]
    [Authorize(Policy = PermissionConstants.Students.Update)]
    public async Task<IActionResult> ActivateStudent(
        long studentProfileId)
    {
        var activated = await _studentService
            .ActivateStudentAsync(studentProfileId);

        if (!activated)
            return NotFound();

        return Ok(new
        {
            Message = "Student activated successfully."
        });
    }

    // ==========================================
    // DEACTIVATE STUDENT
    // ==========================================

    [HttpPut("deactivate/{studentProfileId:long}")]
    [Authorize(Policy = PermissionConstants.Students.Update)]
    public async Task<IActionResult> DeactivateStudent(
        long studentProfileId)
    {
        var deactivated = await _studentService
            .DeactivateStudentAsync(studentProfileId);

        if (!deactivated)
            return NotFound();

        return Ok(new
        {
            Message = "Student deactivated successfully."
        });
    }
}
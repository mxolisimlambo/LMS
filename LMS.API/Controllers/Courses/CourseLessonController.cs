using LMS.Application.Interfaces.Courses;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Courses.Lesson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "courselesson")]
[Route("api/[controller]")]
//[Authorize]
public class CourseLessonController : ControllerBase
{
    private readonly ICourseLessonService _courseLessonService;

    public CourseLessonController(
        ICourseLessonService courseLessonService)
    {
        _courseLessonService = courseLessonService;
    }


    // ======================================================
    // GET LESSON BY ID
    // ======================================================

    [HttpGet("{courseLessonId:long}")]
    // [Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetLessonById(
        long courseLessonId)
    {
        var lesson = await _courseLessonService
            .GetLessonByIdAsync(courseLessonId);

        if (lesson == null)
            return NotFound();

        return Ok(lesson);
    }



    // ======================================================
    // GET LESSONS BY MODULE
    // ======================================================

    [HttpGet("module/{courseModuleId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetLessonsByModule(
        long courseModuleId)
    {
        var lessons = await _courseLessonService
            .GetLessonsByModuleAsync(courseModuleId);

        return Ok(lessons);
    }



    // ======================================================
    // CREATE LESSON
    // ======================================================

    [HttpPost]
    //[Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateLesson(
        CreateCourseLessonDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseLessonService
            .CreateLessonAsync(dto);


        if (!created)
            return BadRequest("Unable to create lesson.");


        return Ok(new
        {
            Message = "Course lesson created successfully."
        });
    }



    // ======================================================
    // UPDATE LESSON
    // ======================================================

    [HttpPut]
    [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateLesson(
        UpdateCourseLessonDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var updated = await _courseLessonService
            .UpdateLessonAsync(dto);


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Course lesson updated successfully."
        });
    }



    // ======================================================
    // DELETE LESSON
    // ======================================================

    [HttpDelete("{courseLessonId:long}")]
    // [Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteLesson(
        long courseLessonId)
    {
        var deleted = await _courseLessonService
            .DeleteLessonAsync(courseLessonId);


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Course lesson deleted successfully."
        });
    }



    // ======================================================
    // REORDER LESSONS
    // ======================================================

    [HttpPut("reorder/{courseModuleId:long}")]
    // [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> ReOrderLessons(
        long courseModuleId,
        [FromBody] List<long> lessonIds)
    {
        var reordered = await _courseLessonService
            .ReOrderLessonsAsync(
                courseModuleId,
                lessonIds);


        if (!reordered)
            return NotFound();


        return Ok(new
        {
            Message = "Course lessons reordered successfully."
        });
    }
}

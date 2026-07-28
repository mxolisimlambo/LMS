using LMS.Application.Interfaces.Courses;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Courses.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "courses")]
[Route("api/[controller]")]
//[Authorize]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(
        ICourseService courseService)
    {
        _courseService = courseService;
    }

    // ==========================================
    // GET COURSE BY ID
    // ==========================================

    [HttpGet("{courseId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetCourseById(
        long courseId)
    {
        var course = await _courseService
            .GetCourseByIdAsync(courseId);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    // ==========================================
    // GET ALL COURSES
    // ==========================================

    [HttpGet]
    //[Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseService
            .GetAllCoursesAsync();

        return Ok(courses);
    }

    // ==========================================
    // GET COURSES BY INSTRUCTOR
    // ==========================================

    [HttpGet("instructor/{instructorProfileId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetCoursesByInstructor(
        long instructorProfileId)
    {
        var courses = await _courseService
            .GetCoursesByInstructorAsync(
                instructorProfileId);

        return Ok(courses);
    }

    // ==========================================
    // GET PUBLISHED COURSES
    // ==========================================

    [HttpGet("published")]
    // [Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetPublishedCourses()
    {
        var courses = await _courseService
            .GetPublishedCoursesAsync();

        return Ok(courses);
    }

    // ==========================================
    // GET DRAFT COURSES
    // ==========================================

    [HttpGet("drafts")]
    // [Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetDraftCourses()
    {
        var courses = await _courseService
            .GetDraftCoursesAsync();

        return Ok(courses);
    }

    // ==========================================
    // CREATE COURSE
    // ==========================================

    [HttpPost]
    //[Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateCourse(
        CreateCourseDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _courseService
            .CreateCourseAsync(dto);

        if (!created)
            return BadRequest("Unable to create course.");

        return Ok(new
        {
            Message = "Course created successfully."
        });
    }

    // ==========================================
    // UPDATE COURSE
    // ==========================================

    [HttpPut]
    //[Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateCourse(
        UpdateCourseDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _courseService
            .UpdateCourseAsync(dto);

        if (!updated)
            return NotFound();

        return Ok(new
        {
            Message = "Course updated successfully."
        });
    }

    // ==========================================
    // DELETE COURSE
    // ==========================================

    [HttpDelete("{courseId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteCourse(
        long courseId)
    {
        var deleted = await _courseService
            .DeleteCourseAsync(courseId);

        if (!deleted)
            return NotFound();

        return Ok(new
        {
            Message = "Course deleted successfully."
        });
    }

    // ==========================================
    // PUBLISH COURSE
    // ==========================================

    [HttpPut("publish/{courseId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> PublishCourse(
        long courseId)
    {
        var published = await _courseService
            .PublishCourseAsync(courseId);

        if (!published)
            return NotFound();

        return Ok(new
        {
            Message = "Course published successfully."
        });
    }

    // ==========================================
    // UNPUBLISH COURSE
    // ==========================================

    [HttpPut("unpublish/{courseId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UnPublishCourse(
        long courseId)
    {
        var unpublished = await _courseService
            .UnPublishCourseAsync(courseId);

        if (!unpublished)
            return NotFound();

        return Ok(new
        {
            Message = "Course unpublished successfully."
        });
    }

    // ==========================================
    // APPROVE COURSE
    // ==========================================

    [HttpPut("approve/{courseId:long}")]
    // [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> ApproveCourse(
        long courseId)
    {
        var approved = await _courseService
            .ApproveCourseAsync(courseId);

        if (!approved)
            return NotFound();

        return Ok(new
        {
            Message = "Course approved successfully."
        });
    }

    // ==========================================
    // REJECT COURSE
    // ==========================================

    [HttpPut("reject/{courseId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> RejectCourse(
        long courseId)
    {
        var rejected = await _courseService
            .RejectCourseAsync(courseId);

        if (!rejected)
            return NotFound();

        return Ok(new
        {
            Message = "Course rejected successfully."
        });
    }

    // ==========================================
    // ARCHIVE COURSE
    // ==========================================

    [HttpPut("archive/{courseId:long}")]
    // [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> ArchiveCourse(
        long courseId)
    {
        var archived = await _courseService
            .ArchiveCourseAsync(courseId);

        if (!archived)
            return NotFound();

        return Ok(new
        {
            Message = "Course archived successfully."
        });
    }

    // ==========================================
    // RESTORE COURSE
    // ==========================================

    [HttpPut("restore/{courseId:long}")]
    // [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> RestoreCourse(
        long courseId)
    {
        var restored = await _courseService
            .RestoreCourseAsync(courseId);

        if (!restored)
            return NotFound();

        return Ok(new
        {
            Message = "Course restored successfully."
        });
    }

    // ==========================================
    // GET COURSE BY SLUG
    // ==========================================

    [HttpGet("slug/{slug}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetCourseBySlug(
        string slug)
    {
        var course = await _courseService
            .GetCourseBySlugAsync(slug);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    // ==========================================
    // SEARCH COURSES
    // ==========================================

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchCourses(
        [FromQuery] string keyword)
    {
        var courses = await _courseService
            .SearchCoursesAsync(keyword);

        return Ok(courses);
    }
}

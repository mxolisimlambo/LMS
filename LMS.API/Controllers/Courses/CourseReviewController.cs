using LMS.Application.Interfaces.Courses;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Courses.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "coursereview")]
[Route("api/[controller]")]
//[Authorize]
public class CourseReviewController : ControllerBase
{
    private readonly ICourseReviewService _courseReviewService;

    public CourseReviewController(
        ICourseReviewService courseReviewService)
    {
        _courseReviewService = courseReviewService;
    }



    // ======================================================
    // CREATE REVIEW
    // ======================================================

    [HttpPost("review")]
    [Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateReview(
        CreateCourseReviewDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseReviewService
            .CreateReviewAsync(dto);


        if (!created)
            return BadRequest("Unable to create course review.");


        return Ok(new
        {
            Message = "Course review created successfully."
        });
    }



    // ======================================================
    // UPDATE REVIEW
    // ======================================================

    [HttpPut("review")]
    [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateReview(
        UpdateCourseReviewDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var updated = await _courseReviewService
            .UpdateReviewAsync(dto);


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Course review updated successfully."
        });
    }



    // ======================================================
    // DELETE REVIEW
    // ======================================================

    [HttpDelete("review/{courseReviewId:long}")]
    [Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteReview(
        long courseReviewId)
    {
        var deleted = await _courseReviewService
            .DeleteReviewAsync(courseReviewId);


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Course review deleted successfully."
        });
    }



    // ======================================================
    // CREATE RATING
    // ======================================================

    [HttpPost("rating")]
    [Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateRating(
        CreateCourseRatingDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseReviewService
            .CreateRatingAsync(dto);


        if (!created)
            return BadRequest(
                "Student has already rated this course.");


        return Ok(new
        {
            Message = "Course rating created successfully."
        });
    }



    // ======================================================
    // GET COURSE REVIEWS
    // ======================================================

    [HttpGet("course/{courseId:long}")]
    [Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetCourseReviews(
        long courseId)
    {
        var reviews = await _courseReviewService
            .GetCourseReviewsAsync(courseId);


        return Ok(reviews);
    }



    // ======================================================
    // GET AVERAGE RATING
    // ======================================================

    [HttpGet("course/{courseId:long}/average-rating")]
    [Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> GetAverageRating(
        long courseId)
    {
        var rating = await _courseReviewService
            .GetAverageRatingAsync(courseId);


        return Ok(new
        {
            CourseId = courseId,
            AverageRating = rating
        });
    }
}

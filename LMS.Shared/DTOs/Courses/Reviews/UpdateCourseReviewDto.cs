//======================================================
// UpdateCourseReviewDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Reviews;

public class UpdateCourseReviewDto
{
    public long CourseReviewId { get; set; }

    public string ReviewTitle { get; set; } = string.Empty;

    public string Review { get; set; } = string.Empty;

    public bool IsRecommended { get; set; }
}

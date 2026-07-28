//======================================================
// CreateCourseReviewDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Reviews;

public class CreateCourseReviewDto
{
    public long CourseId { get; set; }

    public long StudentProfileId { get; set; }

    public string ReviewTitle { get; set; } = string.Empty;

    public string Review { get; set; } = string.Empty;

    public bool IsRecommended { get; set; }
}

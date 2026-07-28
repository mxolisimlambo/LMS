//======================================================
// UpdateCourseRatingDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Reviews;

public class UpdateCourseRatingDto
{
    public long CourseRatingId { get; set; }

    public decimal Rating { get; set; }

    public bool IsVerifiedPurchase { get; set; }
}

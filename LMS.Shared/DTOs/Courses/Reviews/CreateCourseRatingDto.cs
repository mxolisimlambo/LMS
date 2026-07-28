//======================================================
// CreateCourseRatingDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Reviews;

public class CreateCourseRatingDto
{
    public long CourseId { get; set; }

    public long StudentProfileId { get; set; }

    public decimal Rating { get; set; }

    public bool IsVerifiedPurchase { get; set; }
}

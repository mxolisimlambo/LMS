//======================================================
// CourseRatingDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Reviews;

public class CourseRatingDto
{
    public long CourseRatingId { get; set; }

    public long CourseId { get; set; }

    public long StudentProfileId { get; set; }

    public decimal Rating { get; set; }

    public bool IsVerifiedPurchase { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

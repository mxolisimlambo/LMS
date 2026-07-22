using LMS.Domain.Entities.Courses.Catalog;
using LMS.Domain.Entities.Students;

namespace LMS.Domain.Entities.Courses.Reviews;

public class CourseRating
{
    public long CourseRatingId { get; set; }

    public long CourseId { get; set; }

    public long StudentProfileId { get; set; }

    public decimal Rating { get; set; }

    public bool IsVerifiedPurchase { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Properties

    public Course? Course { get; set; }

    public StudentProfile? StudentProfile { get; set; }
}
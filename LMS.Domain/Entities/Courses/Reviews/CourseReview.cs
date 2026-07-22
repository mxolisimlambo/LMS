using LMS.Domain.Entities.Courses.Catalog;
using LMS.Domain.Entities.Students;

namespace LMS.Domain.Entities.Courses.Reviews;

public class CourseReview
{
    public long CourseReviewId { get; set; }

    public long CourseId { get; set; }

    public long StudentProfileId { get; set; }

    public string ReviewTitle { get; set; } = string.Empty;

    public string Review { get; set; } = string.Empty;

    public bool IsRecommended { get; set; }

    public bool IsApproved { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Properties

    public Course? Course { get; set; }

    public StudentProfile? StudentProfile { get; set; }
}
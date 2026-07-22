using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Publishing;

public class CourseApproval
{
    public long CourseApprovalId { get; set; }

    public long CourseId { get; set; }

    public string ApprovalStatus { get; set; } = string.Empty;

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? RejectedBy { get; set; }

    public DateTime? RejectedDate { get; set; }

    public string? RejectionReason { get; set; }

    public string? ReviewComments { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

    public Course? Course { get; set; }
}
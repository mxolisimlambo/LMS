namespace LMS.Domain.Entities.Instructors;

public class InstructorApproval
{
    public long InstructorApprovalId { get; set; }

    public long InstructorProfileId { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }

    public string ApprovalStatus { get; set; } = string.Empty;

    public string? ApprovedByUserId { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public string? RejectionReason { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
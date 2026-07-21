namespace LMS.Domain.Entities.Instructors;

public class InstructorVerification
{
    public long InstructorVerificationId { get; set; }

    public long InstructorProfileId { get; set; }

    public string Status { get; set; } = string.Empty;

    public string? VerifiedBy { get; set; }

    public DateTime? VerifiedDate { get; set; }

    public string? Notes { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}
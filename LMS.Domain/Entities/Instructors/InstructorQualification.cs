namespace LMS.Domain.Entities.Instructors;

public class InstructorQualification
{
    public long InstructorQualificationId { get; set; }

    public long InstructorProfileId { get; set; }

    public string QualificationName { get; set; } = string.Empty;

    public string Institution { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public int CompletedYear { get; set; }

    public string? CertificateFile { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}
namespace LMS.Domain.Entities.Instructors;

public class InstructorCertification
{
    public long InstructorCertificationId { get; set; }

    public long InstructorProfileId { get; set; }

    public string CertificationName { get; set; } = string.Empty;

    public string IssuingOrganization { get; set; } = string.Empty;

    public DateTime IssueDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? CertificateNumber { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}

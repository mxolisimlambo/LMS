namespace LMS.Domain.Entities.Students;

public class StudentEmergencyContact
{
    public long StudentEmergencyContactId { get; set; }

    public long StudentProfileId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Relationship { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string? AlternativePhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public bool IsPrimary { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
    public StudentProfile? StudentProfile { get; set; }
}

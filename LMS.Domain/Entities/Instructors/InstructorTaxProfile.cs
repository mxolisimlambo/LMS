namespace LMS.Domain.Entities.Instructors;

public class InstructorTaxProfile
{
    public long InstructorTaxProfileId { get; set; }

    public long InstructorProfileId { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }

    public string TaxNumber { get; set; } = string.Empty;

    public string? VatNumber { get; set; }

    public string Country { get; set; } = string.Empty;

    public string TaxStatus { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
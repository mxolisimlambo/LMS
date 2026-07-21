namespace LMS.Domain.Entities.Instructors;

public class InstructorAddress
{
    public long InstructorAddressId { get; set; }

    public long InstructorProfileId { get; set; }

    public string AddressType { get; set; } = string.Empty;

    public string AddressLine1 { get; set; } = string.Empty;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = string.Empty;

    public string Province { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}

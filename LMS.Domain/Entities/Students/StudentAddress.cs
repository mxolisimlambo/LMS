namespace LMS.Domain.Entities.Students;

public class StudentAddress
{
    public long StudentAddressId { get; set; }

    public long StudentProfileId { get; set; }

    public string AddressLine1 { get; set; } = string.Empty;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = string.Empty;

    public string StateProvince { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public int CountryId { get; set; }

    public bool IsPrimary { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
    public StudentProfile? StudentProfile { get; set; }
}
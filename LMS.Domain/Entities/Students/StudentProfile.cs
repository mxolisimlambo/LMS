namespace LMS.Domain.Entities.Students;

public class StudentProfile
{
    public long StudentProfileId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string StudentNumber { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public int? GenderId { get; set; }

    public string? Occupation { get; set; }

    public string? Company { get; set; }

    public string? Biography { get; set; }

    public string? ProfilePhoto { get; set; }

    public int? CountryId { get; set; }

    public int? TimeZoneId { get; set; }

    public int? PreferredLanguageId { get; set; }

    public bool IsPremium { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
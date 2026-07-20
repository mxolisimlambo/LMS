namespace LMS.Domain.Entities.Students;

public class StudentProfile
{
    public long StudentProfileId { get; set; }
    public StudentPreference? StudentPreference { get; set; }

    public StudentSettings? StudentSettings { get; set; }

    public StudentNotificationPreference? StudentNotificationPreference { get; set; }

    public StudentSubscription? StudentSubscription { get; set; }

    public ICollection<StudentAddress> StudentAddresses { get; set; }
        = new List<StudentAddress>();

    public ICollection<StudentDocument> StudentDocuments { get; set; }
        = new List<StudentDocument>();

    public ICollection<StudentEmergencyContact> StudentEmergencyContacts { get; set; }
        = new List<StudentEmergencyContact>();

    public ICollection<StudentWishlist> StudentWishlists { get; set; }
        = new List<StudentWishlist>();
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
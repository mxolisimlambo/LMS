namespace LMS.Domain.Entities.Students;

public class StudentPreference
{
    public long StudentPreferenceId { get; set; }

    public long StudentProfileId { get; set; }
    public string Language { get; set; } = "en";

    public string TimeZone { get; set; } = "Africa/Johannesburg";

    public string Theme { get; set; } = "Light";

    public bool EmailNotifications { get; set; }

    public bool SmsNotifications { get; set; }

    public bool PushNotifications { get; set; }

    public bool MarketingEmails { get; set; }

    public bool MarketingSms { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
    public StudentProfile? StudentProfile { get; set; }
}

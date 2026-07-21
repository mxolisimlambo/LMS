namespace LMS.Domain.Entities.Instructors;

public class InstructorNotificationPreference
{
    public long InstructorNotificationPreferenceId { get; set; }

    public long InstructorProfileId { get; set; }

    public bool EmailNotifications { get; set; }

    public bool SmsNotifications { get; set; }

    public bool PushNotifications { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}
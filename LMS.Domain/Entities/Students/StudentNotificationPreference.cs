namespace LMS.Domain.Entities.Students;

public class StudentNotificationPreference
{
    public long StudentNotificationPreferenceId { get; set; }

    public long StudentProfileId { get; set; }
    public bool CourseAnnouncements { get; set; }

    public bool AssignmentReminders { get; set; }

    public bool QuizReminders { get; set; }

    public bool PaymentNotifications { get; set; }

    public bool CertificateNotifications { get; set; }

    public bool InstructorMessages { get; set; }

    public bool MarketingNotifications { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
    public StudentProfile? StudentProfile { get; set; }
}
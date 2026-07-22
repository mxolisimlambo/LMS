using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Publishing;

public class CourseAnnouncement
{
    public long CourseAnnouncementId { get; set; }

    public long CourseId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public bool NotifyStudentsByEmail { get; set; }

    public bool NotifyStudentsInApp { get; set; }

    public DateTime PublishDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

    public Course? Course { get; set; }
}
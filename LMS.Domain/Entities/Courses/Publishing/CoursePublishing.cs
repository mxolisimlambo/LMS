using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Publishing;

public class CoursePublishing
{
    public long CoursePublishingId { get; set; }

    public long CourseId { get; set; }

    public bool IsPublished { get; set; }

    public DateTime? PublishedDate { get; set; }

    public string? PublishedBy { get; set; }

    public DateTime? UnpublishedDate { get; set; }

    public string? UnpublishedReason { get; set; }

    public bool AllowEnrollment { get; set; }

    public bool AllowPreview { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

    public Course? Course { get; set; }
}
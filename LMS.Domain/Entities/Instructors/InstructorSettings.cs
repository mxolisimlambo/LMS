namespace LMS.Domain.Entities.Instructors;

public class InstructorSettings
{
    public long InstructorSettingsId { get; set; }

    public long InstructorProfileId { get; set; }

    public bool AllowPublicProfile { get; set; }

    public bool AllowCourseReviews { get; set; }

    public bool ShowRevenue { get; set; }

    public DateTime CreatedDate { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}
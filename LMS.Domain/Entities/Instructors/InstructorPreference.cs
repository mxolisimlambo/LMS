namespace LMS.Domain.Entities.Instructors;

public class InstructorPreference
{
    public long InstructorPreferenceId { get; set; }

    public long InstructorProfileId { get; set; }

    public string Language { get; set; } = string.Empty;

    public string TimeZone { get; set; } = string.Empty;

    public string Currency { get; set; } = string.Empty;

    public InstructorProfile? InstructorProfile { get; set; }
}
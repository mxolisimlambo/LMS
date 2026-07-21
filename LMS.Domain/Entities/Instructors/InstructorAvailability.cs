namespace LMS.Domain.Entities.Instructors;

public class InstructorAvailability
{
    public long InstructorAvailabilityId { get; set; }

    public long InstructorProfileId { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }

    public string DayOfWeek { get; set; } = string.Empty;

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
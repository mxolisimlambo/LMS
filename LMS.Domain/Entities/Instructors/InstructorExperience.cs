namespace LMS.Domain.Entities.Instructors;

public class InstructorExperience
{
    public long InstructorExperienceId { get; set; }

    public long InstructorProfileId { get; set; }

    public string Company { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}
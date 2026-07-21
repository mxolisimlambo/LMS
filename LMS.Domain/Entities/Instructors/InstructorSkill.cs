namespace LMS.Domain.Entities.Instructors;

public class InstructorSkill
{
    public long InstructorSkillId { get; set; }

    public long InstructorProfileId { get; set; }

    public string SkillName { get; set; } = string.Empty;

    public int YearsExperience { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}

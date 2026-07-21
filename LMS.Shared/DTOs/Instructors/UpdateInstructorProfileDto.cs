namespace LMS.Shared.DTOs.Instructors;

public class UpdateInstructorProfileDto
{
    public long InstructorProfileId { get; set; }

    public string ProfessionalHeadline { get; set; } = string.Empty;

    public string Biography { get; set; } = string.Empty;

    public string? ProfilePhoto { get; set; }

    public string? BannerImage { get; set; }

    public string? Website { get; set; }

    public int YearsExperience { get; set; }

    public bool IsPremium { get; set; }

    public bool IsDeleted { get; set; }
}
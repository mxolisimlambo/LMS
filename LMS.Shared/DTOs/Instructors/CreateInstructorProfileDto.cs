namespace LMS.Shared.DTOs.Instructors;

public class CreateInstructorProfileDto
{
    public string UserId { get; set; } = string.Empty;

    public string InstructorNumber { get; set; } = string.Empty;

    public string ProfessionalHeadline { get; set; } = string.Empty;

    public string Biography { get; set; } = string.Empty;

    public string? ProfilePhoto { get; set; }

    public string? BannerImage { get; set; }

    public string? Website { get; set; }

    public int YearsExperience { get; set; }

    public bool IsPremium { get; set; }
}
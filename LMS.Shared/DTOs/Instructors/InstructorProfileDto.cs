namespace LMS.Shared.DTOs.Instructors;

public class InstructorProfileDto
{
    public long InstructorProfileId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string InstructorNumber { get; set; } = string.Empty;

    public string ProfessionalHeadline { get; set; } = string.Empty;

    public string Biography { get; set; } = string.Empty;

    public string? ProfilePhoto { get; set; }

    public string? BannerImage { get; set; }

    public string? Website { get; set; }

    public int YearsExperience { get; set; }

    public decimal AverageRating { get; set; }

    public int TotalStudents { get; set; }

    public int TotalCourses { get; set; }

    public decimal TotalSales { get; set; }

    public decimal WalletBalance { get; set; }

    public string ApprovalStatus { get; set; } = string.Empty;

    public string VerificationStatus { get; set; } = string.Empty;

    public bool IsPremium { get; set; }

    public DateTime CreatedDate { get; set; }
}
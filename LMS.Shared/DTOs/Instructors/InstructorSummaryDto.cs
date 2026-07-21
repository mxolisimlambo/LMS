namespace LMS.Shared.DTOs.Instructors;

public class InstructorSummaryDto
{
    public long InstructorProfileId { get; set; }

    public string InstructorNumber { get; set; } = string.Empty;

    public string ProfessionalHeadline { get; set; } = string.Empty;

    public decimal AverageRating { get; set; }

    public int TotalStudents { get; set; }

    public int TotalCourses { get; set; }

    public bool IsPremium { get; set; }
}
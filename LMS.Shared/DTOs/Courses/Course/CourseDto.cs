//======================================================
// CourseDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Course;

public class CourseDto
{
    public long CourseId { get; set; }

    public long InstructorProfileId { get; set; }

    public long CourseCategoryId { get; set; }

    public long CourseSubCategoryId { get; set; }

    public long CourseLevelId { get; set; }

    public long CourseLanguageId { get; set; }

    public long CourseStatusId { get; set; }

    public string CourseCode { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Subtitle { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Thumbnail { get; set; } = string.Empty;

    public string PreviewVideo { get; set; } = string.Empty;

    public decimal DurationHours { get; set; }

    public decimal EstimatedStudyHours { get; set; }

    public int MaximumStudents { get; set; }

    public int MinimumStudents { get; set; }

    public bool IsFeatured { get; set; }

    public bool IsPremium { get; set; }

    public bool IsPublished { get; set; }

    public DateTime? PublishedDate { get; set; }

    public string? PublishedBy { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

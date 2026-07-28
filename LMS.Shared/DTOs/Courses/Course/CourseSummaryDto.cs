//======================================================
// CourseSummaryDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Course;

public class CourseSummaryDto
{
    public long CourseId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Thumbnail { get; set; }

    public decimal Price { get; set; }

    public decimal Rating { get; set; }

    public int TotalStudents { get; set; }

    public int TotalLessons { get; set; }

    public bool IsPublished { get; set; }
}

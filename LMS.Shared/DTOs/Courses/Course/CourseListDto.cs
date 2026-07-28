//======================================================
// CourseListDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Course;

public class CourseListDto
{
    public long CourseId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Level { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public decimal Rating { get; set; }

    public bool IsPublished { get; set; }
}

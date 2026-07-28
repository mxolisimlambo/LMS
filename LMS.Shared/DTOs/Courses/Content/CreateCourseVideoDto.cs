//======================================================
// CreateCourseVideoDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class CreateCourseVideoDto
{
    public long CourseLessonId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string VideoUrl { get; set; } = string.Empty;

    public int DurationInSeconds { get; set; }
}

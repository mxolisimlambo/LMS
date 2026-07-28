//======================================================
// UpdateCourseVideoDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class UpdateCourseVideoDto
{
    public long CourseVideoId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string VideoUrl { get; set; } = string.Empty;

    public int DurationInSeconds { get; set; }
}

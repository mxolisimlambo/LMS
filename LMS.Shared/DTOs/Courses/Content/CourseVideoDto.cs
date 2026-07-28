//======================================================
// CourseVideoDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class CourseVideoDto
{
    public long CourseVideoId { get; set; }

    public long CourseLessonId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string VideoUrl { get; set; } = string.Empty;

    public int DurationInSeconds { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }
}

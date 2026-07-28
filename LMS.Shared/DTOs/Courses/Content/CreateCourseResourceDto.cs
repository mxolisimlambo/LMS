//======================================================
// CreateCourseResourceDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class CreateCourseResourceDto
{
    public long CourseLessonId { get; set; }

    public string ResourceName { get; set; } = string.Empty;

    public string ResourceUrl { get; set; } = string.Empty;
}

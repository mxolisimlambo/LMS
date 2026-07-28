//======================================================
// CourseResourceDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class CourseResourceDto
{
    public long CourseResourceId { get; set; }

    public long CourseLessonId { get; set; }

    public string ResourceName { get; set; } = string.Empty;

    public string ResourceUrl { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }
}

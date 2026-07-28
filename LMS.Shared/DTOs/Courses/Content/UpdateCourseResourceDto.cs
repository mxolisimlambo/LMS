//======================================================
// UpdateCourseResourceDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class UpdateCourseResourceDto
{
    public long CourseResourceId { get; set; }

    public string ResourceName { get; set; } = string.Empty;

    public string ResourceUrl { get; set; } = string.Empty;
}

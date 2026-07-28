//======================================================
// CreateCourseModuleDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Module;

public class CreateCourseModuleDto
{
    public long CourseId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int DisplayOrder { get; set; }
}

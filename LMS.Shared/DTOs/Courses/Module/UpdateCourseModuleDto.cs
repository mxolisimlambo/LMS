//======================================================
// UpdateCourseModuleDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Module;

public class UpdateCourseModuleDto
{
    public long CourseModuleId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int DisplayOrder { get; set; }
}

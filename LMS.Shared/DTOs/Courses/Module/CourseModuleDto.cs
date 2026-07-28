//======================================================
// CourseModuleDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Module;

public class CourseModuleDto
{
    public long CourseModuleId { get; set; }

    public long CourseId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }
}

//======================================================
// UpdateCourseAttachmentDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class UpdateCourseAttachmentDto
{
    public long CourseAttachmentId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}

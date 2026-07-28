//======================================================
// CreateCourseAttachmentDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class CreateCourseAttachmentDto
{
    public long CourseLessonId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}

//======================================================
// CourseAttachmentDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class CourseAttachmentDto
{
    public long CourseAttachmentId { get; set; }

    public long CourseLessonId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }
}

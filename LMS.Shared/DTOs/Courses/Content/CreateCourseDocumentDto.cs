//======================================================
// CreateCourseDocumentDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class CreateCourseDocumentDto
{
    public long CourseLessonId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}

//======================================================
// CourseDocumentDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class CourseDocumentDto
{
    public long CourseDocumentId { get; set; }

    public long CourseLessonId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }
}

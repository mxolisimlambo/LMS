//======================================================
// UpdateCourseDocumentDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Content;

public class UpdateCourseDocumentDto
{
    public long CourseDocumentId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}

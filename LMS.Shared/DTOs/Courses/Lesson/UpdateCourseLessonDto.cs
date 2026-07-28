//======================================================
// UpdateCourseLessonDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Lesson;

public class UpdateCourseLessonDto
{
    public long CourseLessonId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsFreePreview { get; set; }
}

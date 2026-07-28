//======================================================
// CourseLessonDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Lesson;

public class CourseLessonDto
{
    public long CourseLessonId { get; set; }

    public long CourseModuleId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsFreePreview { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }
}

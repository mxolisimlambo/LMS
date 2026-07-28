namespace LMS.Shared.DTOs.Courses.CourseLevel;

public class UpdateCourseLevelDto
{
    public long CourseLevelId { get; set; }

    public string LevelName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }
}

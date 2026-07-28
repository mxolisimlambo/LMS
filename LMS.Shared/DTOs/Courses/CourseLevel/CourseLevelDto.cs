namespace LMS.Shared.DTOs.Courses.CourseLevel;

public class CourseLevelDto
{
    public long CourseLevelId { get; set; }

    public string LevelName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

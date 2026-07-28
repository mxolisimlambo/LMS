namespace LMS.Shared.DTOs.Courses.CourseCategory;

public class CreateCourseCategoryDto
{
    public string CategoryName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public string? Image { get; set; }
    public int DisplayOrder { get; set; }
}

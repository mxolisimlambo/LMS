namespace LMS.Shared.DTOs.Courses.CourseSubCategory;

public class CreateCourseSubCategoryDto
{
    public long CourseCategoryId { get; set; }

    public string SubCategoryName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public string? Image { get; set; }
}

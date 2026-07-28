namespace LMS.Shared.DTOs.Courses.CourseSubCategory;

public class CourseSubCategoryDto
{
    public long CourseSubCategoryId { get; set; }

    public long CourseCategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string SubCategoryName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public string? Image { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

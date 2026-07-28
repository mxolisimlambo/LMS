namespace LMS.Shared.DTOs.Courses.CourseCategory;

public class CourseCategoryDto
{
    public long CourseCategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public string? Image { get; set; }

    public int DisplayOrder { get; set; }
    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

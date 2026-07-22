namespace LMS.Domain.Entities.Courses.Catalog;


public class CourseCategory
{
public long CourseCategoryId { get; set; }

public string CategoryName { get; set; } = string.Empty;

public string Description { get; set; } = string.Empty;

public string Icon { get; set; } = string.Empty;

public int DisplayOrder { get; set; }

public bool IsActive { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }
public ICollection<CourseSubCategory> CourseSubCategories { get; set; }
    = new List<CourseSubCategory>();

public ICollection<Course> Courses { get; set; }
    = new List<Course>();
}
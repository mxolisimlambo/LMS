namespace LMS.Domain.Entities.Courses.Catalog;


public class CourseSubCategory
{
public long CourseSubCategoryId { get; set; }

public long CourseCategoryId { get; set; }

public string SubCategoryName { get; set; } = string.Empty;

public string Description { get; set; } = string.Empty;

public int DisplayOrder { get; set; }

public bool IsActive { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }
public CourseCategory? CourseCategory { get; set; }

public ICollection<Course> Courses { get; set; }
    = new List<Course>();
}
namespace LMS.Domain.Entities.Courses.Catalog;


public class CourseLevel
{
public long CourseLevelId { get; set; }

public string LevelName { get; set; } = string.Empty;

public string Description { get; set; } = string.Empty;

public int DisplayOrder { get; set; }

public bool IsActive { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }
    public ICollection<Course> Courses { get; set; }
        = new List<Course>();
    
}
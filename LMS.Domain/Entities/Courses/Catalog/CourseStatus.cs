namespace LMS.Domain.Entities.Courses.Catalog;


public class CourseStatus
{
public long CourseStatusId { get; set; }

public string StatusName { get; set; } = string.Empty;

public string Description { get; set; } = string.Empty;

public bool IsActive { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }
public ICollection<Course> Courses { get; set; }
    = new List<Course>();
}
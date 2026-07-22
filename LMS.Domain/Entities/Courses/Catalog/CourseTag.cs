namespace LMS.Domain.Entities.Courses.Catalog;


public class CourseTag
{
public long CourseTagId { get; set; }

public long CourseId { get; set; }

public string TagName { get; set; } = string.Empty;

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }
public Course? Course { get; set; }
}
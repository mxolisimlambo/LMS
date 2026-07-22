namespace LMS.Domain.Entities.Courses.Catalog;


public class CourseLanguage
{
public long CourseLanguageId { get; set; }

public string LanguageName { get; set; } = string.Empty;

public string LanguageCode { get; set; } = string.Empty;

public bool IsActive { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }
public ICollection<Course> Courses { get; set; }
    = new List<Course>();
}
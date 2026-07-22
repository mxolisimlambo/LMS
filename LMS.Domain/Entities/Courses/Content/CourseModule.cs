using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Content;

public class CourseModule
{
    public long CourseModuleId { get; set; }

public long CourseId { get; set; }

public string ModuleTitle { get; set; } = string.Empty;

public string Description { get; set; } = string.Empty;

public int DisplayOrder { get; set; }

public decimal DurationHours { get; set; }

public bool IsPublished { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }



public Course? Course { get; set; }

public ICollection<CourseLesson> CourseLessons { get; set; }
    = new List<CourseLesson>();
}
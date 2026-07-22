using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Content;

public class CourseResource
{
    public long CourseResourceId { get; set; }

    public long CourseId { get; set; }

    public string ResourceName { get; set; } = string.Empty;

    public string ResourceUrl { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

  public long CourseLessonId { get; set; }

public CourseLesson? CourseLesson { get; set; }
}
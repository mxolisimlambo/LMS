using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Content;

public class CourseLesson
{
    public long CourseLessonId { get; set; }

public long CourseModuleId { get; set; }

public string LessonTitle { get; set; } = string.Empty;

public string Description { get; set; } = string.Empty;

public int DisplayOrder { get; set; }

public decimal DurationMinutes { get; set; }

public bool IsPreview { get; set; }

public bool IsPublished { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }



public CourseModule? CourseModule { get; set; }

public ICollection<CourseVideo> CourseVideos { get; set; }
    = new List<CourseVideo>();

public ICollection<CourseDocument> CourseDocuments { get; set; }
    = new List<CourseDocument>();

public ICollection<CourseAttachment> CourseAttachments { get; set; }
    = new List<CourseAttachment>();

    public ICollection<CourseResource> CourseResources { get; set; }
        = new List<CourseResource>();
    
}
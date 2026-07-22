
namespace LMS.Domain.Entities.Courses.Content;

public class CourseVideo
{
    public long CourseVideoId { get; set; }

public long CourseLessonId { get; set; }

public string VideoTitle { get; set; } = string.Empty;

public string VideoUrl { get; set; } = string.Empty;

public string Thumbnail { get; set; } = string.Empty;

public decimal DurationMinutes { get; set; }

public long FileSize { get; set; }

public bool IsDownloadable { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }



public CourseLesson? CourseLesson { get; set; }
}


namespace LMS.Domain.Entities.Courses.Content;

public class CourseDocument
{
    public long CourseDocumentId { get; set; }

public long CourseLessonId { get; set; }

public string DocumentTitle { get; set; } = string.Empty;

public string FileName { get; set; } = string.Empty;

public string FilePath { get; set; } = string.Empty;

public string FileType { get; set; } = string.Empty;

public long FileSize { get; set; }

public bool IsDownloadable { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }



public CourseLesson? CourseLesson { get; set; }
}
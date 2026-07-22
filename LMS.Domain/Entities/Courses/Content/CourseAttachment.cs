

namespace LMS.Domain.Entities.Courses.Content;

public class CourseAttachment
{
    public long CourseAttachmentId { get; set; }

public long CourseLessonId { get; set; }

public string AttachmentTitle { get; set; } = string.Empty;

public string FileName { get; set; } = string.Empty;

public string FilePath { get; set; } = string.Empty;

public string FileType { get; set; } = string.Empty;

public long FileSize { get; set; }

public DateTime CreatedDate { get; set; }

public bool IsDeleted { get; set; }



public CourseLesson? CourseLesson { get; set; }
}
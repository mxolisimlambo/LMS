namespace LMS.Shared.DTOs.Courses.CourseLanguage;

public class UpdateCourseLanguageDto
{
    public long CourseLanguageId { get; set; }

    public string LanguageName { get; set; } = string.Empty;

    public string LanguageCode { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }
}

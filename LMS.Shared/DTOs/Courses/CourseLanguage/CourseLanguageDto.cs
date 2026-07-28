namespace LMS.Shared.DTOs.Courses.CourseLanguage;

public class CourseLanguageDto
{
    public long CourseLanguageId { get; set; }

    public string LanguageName { get; set; } = string.Empty;

    public string LanguageCode { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

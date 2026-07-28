//======================================================
// UpdateCourseDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Course;

public class UpdateCourseDto
{
    public long CourseId { get; set; }

    public long CourseCategoryId { get; set; }

    public long? CourseSubCategoryId { get; set; }

    public long CourseLevelId { get; set; }

    public long CourseLanguageId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? ShortDescription { get; set; }

    public string? Description { get; set; }

    public string? Thumbnail { get; set; }

    public string? PreviewVideo { get; set; }
}

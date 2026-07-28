using LMS.Shared.DTOs.Courses.CourseLanguage;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseLanguageService
{
    Task<bool> CreateCourseLanguageAsync(CreateCourseLanguageDto dto);

    Task<bool> UpdateCourseLanguageAsync(UpdateCourseLanguageDto dto);

    Task<bool> DeleteCourseLanguageAsync(long courseLanguageId);

    Task<CourseLanguageDto?> GetCourseLanguageByIdAsync(long courseLanguageId);

    Task<IEnumerable<CourseLanguageDto>> GetAllCourseLanguagesAsync();
}

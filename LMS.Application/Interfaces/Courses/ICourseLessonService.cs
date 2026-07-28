using LMS.Shared.DTOs.Courses.Lesson;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseLessonService
{
    Task<bool> CreateLessonAsync(CreateCourseLessonDto dto);

    Task<bool> UpdateLessonAsync(UpdateCourseLessonDto dto);

    Task<bool> DeleteLessonAsync(long courseLessonId);

    Task<CourseLessonDto?> GetLessonByIdAsync(long courseLessonId);

    Task<IEnumerable<CourseLessonDto>> GetLessonsByModuleAsync(
        long courseModuleId);

    Task<bool> ReOrderLessonsAsync(
        long courseModuleId,
        List<long> lessonIds);
}

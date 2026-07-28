using LMS.Shared.DTOs.Courses.Module;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseModuleService
{
    Task<bool> CreateModuleAsync(CreateCourseModuleDto dto);

    Task<bool> UpdateModuleAsync(UpdateCourseModuleDto dto);

    Task<bool> DeleteModuleAsync(long courseModuleId);

    Task<CourseModuleDto?> GetModuleByIdAsync(long courseModuleId);

    Task<IEnumerable<CourseModuleDto>> GetModulesByCourseAsync(
        long courseId);

    Task<bool> ReOrderModulesAsync(
        long courseId,
        List<long> moduleIds);
}

using LMS.Shared.DTOs.Courses.CourseLevel;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseLevelService
{
    Task<bool> CreateCourseLevelAsync(CreateCourseLevelDto dto);

    Task<bool> UpdateCourseLevelAsync(UpdateCourseLevelDto dto);

    Task<bool> DeleteCourseLevelAsync(long courseLevelId);

    Task<CourseLevelDto?> GetCourseLevelByIdAsync(long courseLevelId);

    Task<IEnumerable<CourseLevelDto>> GetAllCourseLevelsAsync();
}

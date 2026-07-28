using LMS.Shared.DTOs.Courses.CourseCategory;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseCategoryService
{
    Task<bool> CreateCourseCategoryAsync(CreateCourseCategoryDto dto);

    Task<bool> UpdateCourseCategoryAsync(UpdateCourseCategoryDto dto);

    Task<bool> DeleteCourseCategoryAsync(long courseCategoryId);

    Task<CourseCategoryDto?> GetCourseCategoryByIdAsync(long courseCategoryId);

    Task<IEnumerable<CourseCategoryDto>> GetAllCourseCategoriesAsync();
}

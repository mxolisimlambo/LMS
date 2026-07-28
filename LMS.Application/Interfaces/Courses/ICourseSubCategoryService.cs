using LMS.Shared.DTOs.Courses.CourseSubCategory;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseSubCategoryService
{
    Task<bool> CreateCourseSubCategoryAsync(CreateCourseSubCategoryDto dto);

    Task<bool> UpdateCourseSubCategoryAsync(UpdateCourseSubCategoryDto dto);

    Task<bool> DeleteCourseSubCategoryAsync(long courseSubCategoryId);

    Task<CourseSubCategoryDto?> GetCourseSubCategoryByIdAsync(long courseSubCategoryId);

    Task<IEnumerable<CourseSubCategoryDto>> GetAllCourseSubCategoriesAsync();

    Task<IEnumerable<CourseSubCategoryDto>> GetByCategoryAsync(
        long courseCategoryId);
}

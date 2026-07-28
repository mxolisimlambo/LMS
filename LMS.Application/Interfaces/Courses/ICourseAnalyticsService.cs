using LMS.Shared.DTOs.Courses.Analytics;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseAnalyticsService
{
    Task<bool> RecordCourseViewAsync(CourseViewDto dto);

    Task<bool> AddToWishlistAsync(CourseWishlistDto dto);

    Task<bool> RemoveFromWishlistAsync(
        long courseId,
        long studentProfileId);

    Task<CourseStatisticsDto?> GetCourseStatisticsAsync(
        long courseId);

    Task<IEnumerable<CourseStatisticsDto>> GetTrendingCoursesAsync();
    Task<IEnumerable<CourseStatisticsDto>> GetPopularCoursesAsync();
    Task<bool> RemoveFromWishlistAsync(long courseWishlistId);
    Task<CourseWishlistDto?> GetWishlistByIdAsync(long courseWishlistId);

    Task<IEnumerable<CourseWishlistDto>> GetStudentWishlistAsync(
        long studentProfileId);
}

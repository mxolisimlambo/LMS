using LMS.Shared.DTOs.Courses.Reviews;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseReviewService
{
    Task<bool> CreateReviewAsync(CreateCourseReviewDto dto);

    Task<bool> UpdateReviewAsync(UpdateCourseReviewDto dto);

    Task<bool> DeleteReviewAsync(long courseReviewId);

    Task<bool> CreateRatingAsync(CreateCourseRatingDto dto);

    Task<IEnumerable<CourseReviewDto>> GetCourseReviewsAsync(
        long courseId);

    Task<decimal> GetAverageRatingAsync(long courseId);
}

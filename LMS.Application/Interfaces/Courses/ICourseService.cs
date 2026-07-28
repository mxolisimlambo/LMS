using LMS.Shared.DTOs.Courses.Course;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseService
{
    Task<bool> CreateCourseAsync(CreateCourseDto dto);

    Task<bool> UpdateCourseAsync(UpdateCourseDto dto);

    Task<bool> DeleteCourseAsync(long courseId);

    Task<CourseDto?> GetCourseByIdAsync(long courseId);

    Task<IEnumerable<CourseListDto>> GetAllCoursesAsync();

    Task<IEnumerable<CourseSummaryDto>> GetCoursesByInstructorAsync(
        long instructorProfileId);

    Task<IEnumerable<CourseSummaryDto>> GetPublishedCoursesAsync();

    Task<IEnumerable<CourseSummaryDto>> GetDraftCoursesAsync();

    Task<bool> PublishCourseAsync(long courseId);

    Task<bool> UnPublishCourseAsync(long courseId);

    Task<bool> ApproveCourseAsync(long courseId);

    Task<bool> RejectCourseAsync(long courseId);

    Task<bool> ArchiveCourseAsync(long courseId);

    Task<bool> RestoreCourseAsync(long courseId);

    Task<CourseSummaryDto?> GetCourseBySlugAsync(string slug);

    Task<IEnumerable<CourseSummaryDto>> SearchCoursesAsync(string keyword);
}

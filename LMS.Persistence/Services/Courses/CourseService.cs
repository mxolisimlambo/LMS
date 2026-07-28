using LMS.Application.Interfaces;
using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Catalog;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.Course;
using Microsoft.EntityFrameworkCore;




public class CourseService : ICourseService
{
    private readonly ApplicationDbContext _context;

    public CourseService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CourseDto?> GetCourseByIdAsync(
        long courseId)
    {
        return await _context.Courses
            .Where(x => x.CourseId == courseId)
            .Select(x => new CourseDto
            {
                CourseId = x.CourseId,
                InstructorProfileId = x.InstructorProfileId,
                CourseCategoryId = x.CourseCategoryId,
                CourseSubCategoryId = x.CourseSubCategoryId,
                CourseLevelId = x.CourseLevelId,
                CourseLanguageId = x.CourseLanguageId,
                CourseStatusId = x.CourseStatusId,

                CourseCode = x.CourseCode,
                Title = x.Title,
                Subtitle = x.Subtitle,
                Description = x.Description,

                Thumbnail = x.Thumbnail,
                PreviewVideo = x.PreviewVideo,

                DurationHours = x.DurationHours,
                EstimatedStudyHours = x.EstimatedStudyHours,

                MaximumStudents = x.MaximumStudents,
                MinimumStudents = x.MinimumStudents,

                IsFeatured = x.IsFeatured,
                IsPremium = x.IsPremium,
                IsPublished = x.IsPublished,

                PublishedDate = x.PublishedDate,
                PublishedBy = x.PublishedBy,
                ApprovedBy = x.ApprovedBy,

                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,

                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CourseListDto>>
        GetAllCoursesAsync()
    {
        return await _context.Courses
            .OrderBy(x => x.Title)
            .Select(x => new CourseListDto
            {
                CourseId = x.CourseId,

                Title = x.Title,

            })
            .ToListAsync();
    }

    public async Task<IEnumerable<CourseSummaryDto>>
        GetCoursesByInstructorAsync(
            long instructorProfileId)
    {
        return await _context.Courses
            .Where(x =>
                x.InstructorProfileId == instructorProfileId)
            .OrderBy(x => x.Title)
            .Select(x => new CourseSummaryDto
            {
                CourseId = x.CourseId,

                Title = x.Title,

                Thumbnail = x.Thumbnail,

                IsPublished = x.IsPublished,
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<CourseSummaryDto>>

    GetPublishedCoursesAsync()
    {
        return await _context.Courses
            .Where(x => x.IsPublished && !x.IsDeleted)
            .OrderBy(x => x.Title)
            .Select(x => new CourseSummaryDto
            {
                CourseId = x.CourseId,

                Title = x.Title,
                Thumbnail = x.Thumbnail,

                IsPublished = x.IsPublished,

            })
            .ToListAsync();
    }

    public async Task<IEnumerable<CourseSummaryDto>>
        GetDraftCoursesAsync()
    {
        return await _context.Courses
            .Where(x => !x.IsPublished && !x.IsDeleted)
            .OrderBy(x => x.Title)
            .Select(x => new CourseSummaryDto
            {
                CourseId = x.CourseId,

                Title = x.Title,
                Thumbnail = x.Thumbnail,

                IsPublished = x.IsPublished,

            })
            .ToListAsync();
    }

    public async Task<bool> CreateCourseAsync(
        CreateCourseDto dto)
    {
        var exists = await _context.Courses
            .AnyAsync(x => x.CourseCode == dto.CourseCode);

        if (exists)
            return false;

        var course = new Course
        {
            InstructorProfileId = dto.InstructorProfileId,
            CourseSubCategoryId = dto.CourseSubCategoryId,
            CourseCategoryId = dto.CourseCategoryId,
            CourseLevelId = dto.CourseLevelId,
            CourseLanguageId = dto.CourseLanguageId,
            Title = dto.Title,
            Description = dto.Description,
            Thumbnail = dto.Thumbnail,
            PreviewVideo = dto.PreviewVideo,
            IsPublished = false,
            PublishedDate = null,
            PublishedBy = null,
            ApprovedBy = null,
            CourseStatusId = 1,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.Courses.Add(course);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateCourseAsync(
        UpdateCourseDto dto)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(x =>
                x.CourseId == dto.CourseId);

        if (course == null)
            return false;

        course.CourseCategoryId = dto.CourseCategoryId;
        course.CourseLevelId = dto.CourseLevelId;
        course.CourseLanguageId = dto.CourseLanguageId;

        course.Title = dto.Title;
        course.Description = dto.Description;

        course.Thumbnail = dto.Thumbnail;
        course.PreviewVideo = dto.PreviewVideo;



        course.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteCourseAsync(
        long courseId)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(x =>
                x.CourseId == courseId);

        if (course == null)
            return false;

        course.IsDeleted = true;
        course.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> PublishCourseAsync(
        long courseId)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(x =>
                x.CourseId == courseId);

        if (course == null)
            return false;

        course.IsPublished = true;
        course.PublishedDate = DateTime.UtcNow;
        course.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UnPublishCourseAsync(
        long courseId)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(x =>
                x.CourseId == courseId);

        if (course == null)
            return false;

        course.IsPublished = false;
        course.PublishedDate = null;
        course.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ApproveCourseAsync(
        long courseId)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(x =>
                x.CourseId == courseId);

        if (course == null)
            return false;

        course.ApprovedBy = "System";
        course.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RejectCourseAsync(
        long courseId)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(x =>
                x.CourseId == courseId);

        if (course == null)
            return false;

        course.ApprovedBy = null;
        course.IsPublished = false;
        course.PublishedDate = null;
        course.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ArchiveCourseAsync(
        long courseId)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(x =>
                x.CourseId == courseId);

        if (course == null)
            return false;

        course.IsDeleted = true;
        course.IsPublished = false;
        course.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RestoreCourseAsync(
        long courseId)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(x =>
                x.CourseId == courseId);

        if (course == null)
            return false;

        course.IsDeleted = false;
        course.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<CourseSummaryDto?>
        GetCourseBySlugAsync(
            string slug)
    {
        return await _context.Courses
            .Where(x =>
                x.CourseCode == slug &&
                !x.IsDeleted)
            .Select(x => new CourseSummaryDto
            {
                CourseId = x.CourseId,

                Title = x.Title,
                Thumbnail = x.Thumbnail,

                IsPublished = x.IsPublished,

            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CourseSummaryDto>>
        SearchCoursesAsync(
            string keyword)
    {
        keyword = keyword?.Trim() ?? string.Empty;

        return await _context.Courses
            .Where(x =>
                !x.IsDeleted &&
                (
                    x.Title.Contains(keyword) ||
                    x.Subtitle.Contains(keyword) ||
                    x.Description.Contains(keyword) ||
                    x.CourseCode.Contains(keyword)
                ))
            .OrderBy(x => x.Title)
            .Select(x => new CourseSummaryDto
            {
                CourseId = x.CourseId,

                Title = x.Title,
                Thumbnail = x.Thumbnail,

                IsPublished = x.IsPublished,

            })
            .ToListAsync();
    }

}

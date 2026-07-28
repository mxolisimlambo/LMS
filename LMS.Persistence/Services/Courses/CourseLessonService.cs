using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Content;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.Lesson;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Courses;

public class CourseLessonService : ICourseLessonService
{
    private readonly ApplicationDbContext _context;

    public CourseLessonService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateLessonAsync(
        CreateCourseLessonDto dto)
    {
        var lesson = new CourseLesson
        {
            CourseModuleId = dto.CourseModuleId,
            LessonTitle = dto.Title,
            Description = dto.Description ?? string.Empty,
            DisplayOrder = dto.DisplayOrder,
            IsPreview = dto.IsFreePreview,

            DurationMinutes = 0,
            IsPublished = false,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseLessons.Add(lesson);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateLessonAsync(
        UpdateCourseLessonDto dto)
    {
        var lesson = await _context.CourseLessons
            .FirstOrDefaultAsync(x =>
                x.CourseLessonId == dto.CourseLessonId);

        if (lesson == null)
            return false;

        lesson.LessonTitle = dto.Title;
        lesson.Description = dto.Description ?? string.Empty;
        lesson.DisplayOrder = dto.DisplayOrder;
        lesson.IsPreview = dto.IsFreePreview;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteLessonAsync(
        long courseLessonId)
    {
        var lesson = await _context.CourseLessons
            .FirstOrDefaultAsync(x =>
                x.CourseLessonId == courseLessonId);

        if (lesson == null)
            return false;

        lesson.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<CourseLessonDto?> GetLessonByIdAsync(
        long courseLessonId)
    {
        return await _context.CourseLessons
            .Where(x => x.CourseLessonId == courseLessonId)
            .Select(x => new CourseLessonDto
            {
                CourseLessonId = x.CourseLessonId,
                CourseModuleId = x.CourseModuleId,
                Title = x.LessonTitle,
                Description = x.Description,
                DisplayOrder = x.DisplayOrder,
                IsFreePreview = x.IsPreview,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CourseLessonDto>>
        GetLessonsByModuleAsync(
            long courseModuleId)
    {
        return await _context.CourseLessons
            .Where(x =>
                x.CourseModuleId == courseModuleId &&
                !x.IsDeleted)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new CourseLessonDto
            {
                CourseLessonId = x.CourseLessonId,
                CourseModuleId = x.CourseModuleId,
                Title = x.LessonTitle,
                Description = x.Description,
                DisplayOrder = x.DisplayOrder,
                IsFreePreview = x.IsPreview,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })
            .ToListAsync();
    }

    public async Task<bool> ReOrderLessonsAsync(
        long courseModuleId,
        List<long> lessonIds)
    {
        var lessons = await _context.CourseLessons
            .Where(x =>
                x.CourseModuleId == courseModuleId &&
                lessonIds.Contains(x.CourseLessonId))
            .ToListAsync();

        if (!lessons.Any())
            return false;

        for (int i = 0; i < lessonIds.Count; i++)
        {
            var lesson = lessons
                .FirstOrDefault(x =>
                    x.CourseLessonId == lessonIds[i]);

            if (lesson != null)
            {
                lesson.DisplayOrder = i + 1;
            }
        }

        await _context.SaveChangesAsync();

        return true;
    }
}

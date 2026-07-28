using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Catalog;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.CourseLanguage;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Courses;

public class CourseLanguageService : ICourseLanguageService
{
    private readonly ApplicationDbContext _context;

    public CourseLanguageService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CourseLanguageDto?> GetCourseLanguageByIdAsync(
        long courseLanguageId)
    {
        return await _context.CourseLanguages

            .Where(x => x.CourseLanguageId == courseLanguageId)

            .Select(x => new CourseLanguageDto
            {
                CourseLanguageId = x.CourseLanguageId,
                LanguageName = x.LanguageName,
                LanguageCode = x.LanguageCode,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })

            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CourseLanguageDto>>
        GetAllCourseLanguagesAsync()
    {
        return await _context.CourseLanguages

            .Where(x => !x.IsDeleted)

            .OrderBy(x => x.LanguageName)

            .Select(x => new CourseLanguageDto
            {
                CourseLanguageId = x.CourseLanguageId,
                LanguageName = x.LanguageName,
                LanguageCode = x.LanguageCode,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })

            .ToListAsync();
    }

    public async Task<bool> CreateCourseLanguageAsync(
        CreateCourseLanguageDto dto)
    {
        var exists = await _context.CourseLanguages

            .AnyAsync(x =>
                x.LanguageName == dto.LanguageName);

        if (exists)
            return false;

        var entity = new CourseLanguage
        {
            LanguageName = dto.LanguageName,
            LanguageCode = dto.LanguageCode,
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseLanguages.Add(entity);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateCourseLanguageAsync(
        UpdateCourseLanguageDto dto)
    {
        var entity = await _context.CourseLanguages

            .FirstOrDefaultAsync(x =>
                x.CourseLanguageId == dto.CourseLanguageId);

        if (entity == null)
            return false;

        entity.LanguageName = dto.LanguageName;
        entity.LanguageCode = dto.LanguageCode;
        entity.IsDeleted = dto.IsDeleted;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCourseLanguageAsync(
        long courseLanguageId)
    {
        var entity = await _context.CourseLanguages

            .FirstOrDefaultAsync(x =>
                x.CourseLanguageId == courseLanguageId);

        if (entity == null)
            return false;

        entity.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }
}

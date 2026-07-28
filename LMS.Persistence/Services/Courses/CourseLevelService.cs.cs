using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Catalog;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.CourseLevel;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Courses;

public class CourseLevelService : ICourseLevelService
{
    private readonly ApplicationDbContext _context;

    public CourseLevelService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CourseLevelDto?> GetCourseLevelByIdAsync(
        long courseLevelId)
    {
        return await _context.CourseLevels

            .Where(x => x.CourseLevelId == courseLevelId)

            .Select(x => new CourseLevelDto
            {
                CourseLevelId = x.CourseLevelId,
                LevelName = x.LevelName,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })

            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CourseLevelDto>>
        GetAllCourseLevelsAsync()
    {
        return await _context.CourseLevels

            .Where(x => !x.IsDeleted)

            .OrderBy(x => x.LevelName)

            .Select(x => new CourseLevelDto
            {
                CourseLevelId = x.CourseLevelId,
                LevelName = x.LevelName,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })

            .ToListAsync();
    }

    public async Task<bool> CreateCourseLevelAsync(
        CreateCourseLevelDto dto)
    {
        var exists = await _context.CourseLevels

            .AnyAsync(x =>
                x.LevelName == dto.LevelName);

        if (exists)
            return false;

        var entity = new CourseLevel
        {
            LevelName = dto.LevelName,
            Description = dto.Description,
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseLevels.Add(entity);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateCourseLevelAsync(
        UpdateCourseLevelDto dto)
    {
        var entity = await _context.CourseLevels

            .FirstOrDefaultAsync(x =>
                x.CourseLevelId == dto.CourseLevelId);

        if (entity == null)
            return false;

        entity.LevelName = dto.LevelName;
        entity.Description = dto.Description;
        entity.IsDeleted = dto.IsDeleted;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCourseLevelAsync(
        long courseLevelId)
    {
        var entity = await _context.CourseLevels

            .FirstOrDefaultAsync(x =>
                x.CourseLevelId == courseLevelId);

        if (entity == null)
            return false;

        entity.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }
}

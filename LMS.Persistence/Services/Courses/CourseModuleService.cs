using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Content;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.Module;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Courses;

public class CourseModuleService : ICourseModuleService
{
    private readonly ApplicationDbContext _context;

    public CourseModuleService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateModuleAsync(
        CreateCourseModuleDto dto)
    {
        var module = new CourseModule
        {
            CourseId = dto.CourseId,
            ModuleTitle = dto.Title,
            Description = dto.Description ?? string.Empty,
            DisplayOrder = dto.DisplayOrder,

            DurationHours = 0,
            IsPublished = false,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseModules.Add(module);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateModuleAsync(
        UpdateCourseModuleDto dto)
    {
        var module = await _context.CourseModules
            .FirstOrDefaultAsync(x =>
                x.CourseModuleId == dto.CourseModuleId);

        if (module == null)
            return false;

        module.ModuleTitle = dto.Title;
        module.Description = dto.Description ?? string.Empty;
        module.DisplayOrder = dto.DisplayOrder;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteModuleAsync(
        long courseModuleId)
    {
        var module = await _context.CourseModules
            .FirstOrDefaultAsync(x =>
                x.CourseModuleId == courseModuleId);

        if (module == null)
            return false;

        module.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<CourseModuleDto?> GetModuleByIdAsync(
        long courseModuleId)
    {
        return await _context.CourseModules
            .Where(x =>
                x.CourseModuleId == courseModuleId)
            .Select(x => new CourseModuleDto
            {
                CourseModuleId = x.CourseModuleId,
                CourseId = x.CourseId,
                Title = x.ModuleTitle,
                Description = x.Description,
                DisplayOrder = x.DisplayOrder,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CourseModuleDto>>
        GetModulesByCourseAsync(
            long courseId)
    {
        return await _context.CourseModules
            .Where(x =>
                x.CourseId == courseId &&
                !x.IsDeleted)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new CourseModuleDto
            {
                CourseModuleId = x.CourseModuleId,
                CourseId = x.CourseId,
                Title = x.ModuleTitle,
                Description = x.Description,
                DisplayOrder = x.DisplayOrder,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })
            .ToListAsync();
    }

    public async Task<bool> ReOrderModulesAsync(
        long courseId,
        List<long> moduleIds)
    {
        var modules = await _context.CourseModules
            .Where(x =>
                x.CourseId == courseId &&
                moduleIds.Contains(x.CourseModuleId))
            .ToListAsync();

        if (!modules.Any())
            return false;

        for (int i = 0; i < moduleIds.Count; i++)
        {
            var module = modules
                .FirstOrDefault(x =>
                    x.CourseModuleId == moduleIds[i]);

            if (module != null)
            {
                module.DisplayOrder = i + 1;
            }
        }

        await _context.SaveChangesAsync();

        return true;
    }
}

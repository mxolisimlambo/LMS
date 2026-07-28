using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Catalog;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.CourseCategory;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Courses;

public class CourseCategoryService : ICourseCategoryService
{
    private readonly ApplicationDbContext _context;

    public CourseCategoryService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CourseCategoryDto?> GetCourseCategoryByIdAsync(
        long courseCategoryId)
    {
        return await _context.CourseCategories

            .Where(x =>
                x.CourseCategoryId == courseCategoryId)

            .Select(x => new CourseCategoryDto
            {
                CourseCategoryId = x.CourseCategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Icon = x.Icon,
                DisplayOrder = x.DisplayOrder,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })

            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CourseCategoryDto>>
        GetAllCourseCategoriesAsync()
    {
        return await _context.CourseCategories

            .Where(x => !x.IsDeleted)

            .OrderBy(x => x.CategoryName)

            .Select(x => new CourseCategoryDto
            {
                CourseCategoryId = x.CourseCategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Icon = x.Icon,
                DisplayOrder = x.DisplayOrder,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })

            .ToListAsync();
    }

    public async Task<bool> CreateCourseCategoryAsync(
        CreateCourseCategoryDto dto)
    {
        var exists = await _context.CourseCategories

            .AnyAsync(x =>
                x.CategoryName == dto.CategoryName);

        if (exists)
            return false;

        var entity = new CourseCategory
        {
            CategoryName = dto.CategoryName,
            Description = dto.Description,
            Icon = dto.Icon,
            DisplayOrder = dto.DisplayOrder,
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseCategories.Add(entity);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateCourseCategoryAsync(
        UpdateCourseCategoryDto dto)
    {
        var entity = await _context.CourseCategories

            .FirstOrDefaultAsync(x =>
                x.CourseCategoryId == dto.CourseCategoryId);

        if (entity == null)
            return false;

        entity.CategoryName = dto.CategoryName;
        entity.Description = dto.Description;
        entity.Icon = dto.Icon;
        entity.DisplayOrder = dto.DisplayOrder;
        entity.IsDeleted = dto.IsDeleted;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCourseCategoryAsync(
        long courseCategoryId)
    {
        var entity = await _context.CourseCategories

            .FirstOrDefaultAsync(x =>
                x.CourseCategoryId == courseCategoryId);

        if (entity == null)
            return false;

        entity.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }
}

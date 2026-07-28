using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Catalog;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.CourseSubCategory;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Courses;

public class CourseSubCategoryService : ICourseSubCategoryService
{
    private readonly ApplicationDbContext _context;

    public CourseSubCategoryService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CourseSubCategoryDto?> GetCourseSubCategoryByIdAsync(
        long courseSubCategoryId)
    {
        return await _context.CourseSubCategories

            .Where(x => x.CourseSubCategoryId == courseSubCategoryId)

            .Select(x => new CourseSubCategoryDto
            {
                CourseSubCategoryId = x.CourseSubCategoryId,
                CourseCategoryId = x.CourseCategoryId,
                CategoryName = x.CourseCategory!.CategoryName,
                SubCategoryName = x.SubCategoryName,
                Description = x.Description,
                //  Icon = x.Icon,
                // Image = x.Image,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })

            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CourseSubCategoryDto>>
        GetAllCourseSubCategoriesAsync()
    {
        return await _context.CourseSubCategories

            .Where(x => !x.IsDeleted)

            .OrderBy(x => x.SubCategoryName)

            .Select(x => new CourseSubCategoryDto
            {
                CourseSubCategoryId = x.CourseSubCategoryId,
                CourseCategoryId = x.CourseCategoryId,
                CategoryName = x.CourseCategory!.CategoryName,
                SubCategoryName = x.SubCategoryName,
                Description = x.Description,
                //Icon = x.Icon,
                //Image = x.Image,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })

            .ToListAsync();
    }

    public async Task<IEnumerable<CourseSubCategoryDto>>
        GetByCategoryAsync(long courseCategoryId)
    {
        return await _context.CourseSubCategories

            .Where(x =>
                x.CourseCategoryId == courseCategoryId &&
                !x.IsDeleted)

            .OrderBy(x => x.SubCategoryName)

            .Select(x => new CourseSubCategoryDto
            {
                CourseSubCategoryId = x.CourseSubCategoryId,
                CourseCategoryId = x.CourseCategoryId,
                CategoryName = x.CourseCategory!.CategoryName,
                SubCategoryName = x.SubCategoryName,
                Description = x.Description,
                //Icon = x.Icon,
                //Image = x.Image,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })

            .ToListAsync();
    }

    public async Task<bool> CreateCourseSubCategoryAsync(
        CreateCourseSubCategoryDto dto)
    {
        var exists = await _context.CourseSubCategories

            .AnyAsync(x =>
                x.CourseCategoryId == dto.CourseCategoryId &&
                x.SubCategoryName == dto.SubCategoryName);

        if (exists)
            return false;

        var entity = new CourseSubCategory
        {
            CourseCategoryId = dto.CourseCategoryId,
            SubCategoryName = dto.SubCategoryName,
            Description = dto.Description,
            // Icon = dto.Icon,
            //Image = dto.Image,
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseSubCategories.Add(entity);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateCourseSubCategoryAsync(
        UpdateCourseSubCategoryDto dto)
    {
        var entity = await _context.CourseSubCategories

            .FirstOrDefaultAsync(x =>
                x.CourseSubCategoryId == dto.CourseSubCategoryId);

        if (entity == null)
            return false;

        entity.CourseCategoryId = dto.CourseCategoryId;
        entity.SubCategoryName = dto.SubCategoryName;
        entity.Description = dto.Description;
        // entity.Icon = dto.Icon;
        //entity.Image = dto.Image;
        entity.IsDeleted = dto.IsDeleted;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCourseSubCategoryAsync(
        long courseSubCategoryId)
    {
        var entity = await _context.CourseSubCategories

            .FirstOrDefaultAsync(x =>
                x.CourseSubCategoryId == courseSubCategoryId);

        if (entity == null)
            return false;

        entity.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }
}

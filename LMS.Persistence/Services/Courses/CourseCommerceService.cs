using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Commerce;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.Commerce;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Courses;

public class CourseCommerceService : ICourseCommerceService
{
    private readonly ApplicationDbContext _context;

    public CourseCommerceService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    //=========================================================
    // Course Price
    //=========================================================

    public async Task<bool> CreatePriceAsync(
        CreateCoursePriceDto dto)
    {
        var exists = await _context.CoursePrices
            .AnyAsync(x => x.CourseId == dto.CourseId &&
                           !x.IsDeleted);

        if (exists)
            return false;

        var price = new CoursePrice
        {
            CourseId = dto.CourseId,
            Price = dto.Price,
            OriginalPrice = dto.Price,
            CurrencyCode = dto.Currency,

            TaxPercentage = 0,
            IncludesTax = false,
            IsFree = dto.Price <= 0,

            EffectiveFrom = DateTime.UtcNow,
            EffectiveTo = null,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CoursePrices.Add(price);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdatePriceAsync(
        UpdateCoursePriceDto dto)
    {
        var price = await _context.CoursePrices
            .FirstOrDefaultAsync(x =>
                x.CoursePriceId == dto.CoursePriceId);

        if (price == null)
            return false;

        price.Price = dto.Price;
        price.CurrencyCode = dto.Currency;
        price.IsFree = dto.Price <= 0;

        await _context.SaveChangesAsync();

        return true;
    }

    //=========================================================
    // Course Discount
    //=========================================================

    public async Task<bool> CreateDiscountAsync(
        CreateCourseDiscountDto dto)
    {
        var discount = new CourseDiscount
        {
            CourseId = dto.CourseId,

            DiscountName = "Course Discount",

            DiscountAmount = dto.DiscountAmount,
            DiscountPercentage = 0,

            StartDate = dto.StartDate,
            EndDate = dto.EndDate,

            IsActive = true,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseDiscounts.Add(discount);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateDiscountAsync(
        UpdateCourseDiscountDto dto)
    {
        var discount = await _context.CourseDiscounts
            .FirstOrDefaultAsync(x =>
                x.CourseDiscountId ==
                dto.CourseDiscountId);

        if (discount == null)
            return false;

        discount.DiscountAmount =
            dto.DiscountAmount;

        discount.StartDate =
            dto.StartDate;

        discount.EndDate =
            dto.EndDate;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteDiscountAsync(
        long courseDiscountId)
    {
        var discount = await _context.CourseDiscounts
            .FirstOrDefaultAsync(x =>
                x.CourseDiscountId ==
                courseDiscountId);

        if (discount == null)
            return false;

        discount.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

    //=========================================================
    // Course Coupon
    //=========================================================

    public async Task<bool> CreateCouponAsync(
        CreateCourseCouponDto dto)
    {
        var exists = await _context.CourseCoupons
            .AnyAsync(x =>
                x.CouponCode == dto.CouponCode &&
                !x.IsDeleted);

        if (exists)
            return false;

        var coupon = new CourseCoupon
        {
            CourseId = dto.CourseId,
            CouponCode = dto.CouponCode,
            Description = string.Empty,

            DiscountAmount = dto.DiscountAmount,
            DiscountPercentage = 0,

            MaximumUsage = 0,
            UsedCount = 0,

            StartDate = DateTime.UtcNow,
            EndDate = dto.ExpiryDate,

            IsActive = true,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseCoupons.Add(coupon);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateCouponAsync(
        UpdateCourseCouponDto dto)
    {
        var coupon = await _context.CourseCoupons
            .FirstOrDefaultAsync(x =>
                x.CourseCouponId == dto.CourseCouponId);

        if (coupon == null)
            return false;

        coupon.CouponCode = dto.CouponCode;
        coupon.DiscountAmount = dto.DiscountAmount;
        coupon.EndDate = dto.ExpiryDate;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCouponAsync(
        long courseCouponId)
    {
        var coupon = await _context.CourseCoupons
            .FirstOrDefaultAsync(x =>
                x.CourseCouponId == courseCouponId);

        if (coupon == null)
            return false;

        coupon.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<CourseCouponDto?> ValidateCouponAsync(
        string couponCode)
    {
        return await _context.CourseCoupons
            .Where(x =>
                x.CouponCode == couponCode &&
                x.IsActive &&
                !x.IsDeleted &&
                x.StartDate <= DateTime.UtcNow &&
                x.EndDate >= DateTime.UtcNow)
            .Select(x => new CourseCouponDto
            {
                CourseCouponId = x.CourseCouponId,
                CourseId = x.CourseId,
                CouponCode = x.CouponCode,
                DiscountAmount = x.DiscountAmount,
                ExpiryDate = x.EndDate,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }
}

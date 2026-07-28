using LMS.Shared.DTOs.Courses.Commerce;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseCommerceService
{
    Task<bool> CreatePriceAsync(CreateCoursePriceDto dto);

    Task<bool> UpdatePriceAsync(UpdateCoursePriceDto dto);

    Task<bool> CreateDiscountAsync(CreateCourseDiscountDto dto);

    Task<bool> UpdateDiscountAsync(UpdateCourseDiscountDto dto);

    Task<bool> DeleteDiscountAsync(long courseDiscountId);

    Task<bool> CreateCouponAsync(CreateCourseCouponDto dto);

    Task<bool> UpdateCouponAsync(UpdateCourseCouponDto dto);

    Task<bool> DeleteCouponAsync(long courseCouponId);

    Task<CourseCouponDto?> ValidateCouponAsync(
        string couponCode);
}

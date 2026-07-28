//======================================================
// UpdateCourseCouponDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Commerce;

public class UpdateCourseCouponDto
{
    public long CourseCouponId { get; set; }

    public string CouponCode { get; set; } = string.Empty;

    public decimal DiscountAmount { get; set; }

    public DateTime ExpiryDate { get; set; }
}

//======================================================
// CourseCouponDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Commerce;

public class CourseCouponDto
{
    public long CourseCouponId { get; set; }

    public long CourseId { get; set; }

    public string CouponCode { get; set; } = string.Empty;

    public decimal DiscountAmount { get; set; }

    public DateTime ExpiryDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

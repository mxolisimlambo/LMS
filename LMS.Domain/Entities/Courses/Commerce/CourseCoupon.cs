using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Commerce;

public class CourseCoupon
{
    public long CourseCouponId { get; set; }

    public long CourseId { get; set; }

    public string CouponCode { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal DiscountPercentage { get; set; }

    public decimal DiscountAmount { get; set; }

    public int MaximumUsage { get; set; }

    public int UsedCount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

    public Course? Course { get; set; }
}
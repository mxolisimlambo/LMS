using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Commerce;

public class CourseDiscount
{
    public long CourseDiscountId { get; set; }

    public long CourseId { get; set; }

    public string DiscountName { get; set; } = string.Empty;

    public decimal DiscountPercentage { get; set; }

    public decimal DiscountAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

    public Course? Course { get; set; }
}
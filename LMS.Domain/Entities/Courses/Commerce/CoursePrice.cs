using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Commerce;

public class CoursePrice
{
    public long CoursePriceId { get; set; }

    public long CourseId { get; set; }

    public decimal Price { get; set; }

    public decimal OriginalPrice { get; set; }

    public string CurrencyCode { get; set; } = "ZAR";

    public decimal TaxPercentage { get; set; }

    public bool IncludesTax { get; set; }

    public bool IsFree { get; set; }

    public DateTime EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

    public Course? Course { get; set; }
}
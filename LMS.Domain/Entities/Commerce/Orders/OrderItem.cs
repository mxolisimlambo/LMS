using LMS.Domain.Entities.Courses.Catalog;
using LMS.Domain.Entities.Enrollments;

namespace LMS.Domain.Entities.Commerce.Orders;

public class OrderItem
{
    public long OrderItemId { get; set; }

    public long OrderId { get; set; }

    public long CourseId { get; set; }

    public string CourseTitle { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation properties

    public Order? Order { get; set; }

    public Course? Course { get; set; }

// ======================================================
// ENROLMENT
// ======================================================
public Enrollment? Enrollment { get; set; }
}
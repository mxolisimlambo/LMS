using LMS.Domain.Entities.Students;
using LMS.Domain.Entities.Payments;


namespace LMS.Domain.Entities.Commerce.Orders;

public class Order
{
    public long OrderId { get; set; }

    public long StudentProfileId { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public decimal SubTotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public string OrderStatus { get; set; } = "Pending";

    public DateTime OrderDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation properties
// ======================================================
// PAYMENT
// ======================================================

    public Payment? Payment { get; set; }
    public StudentProfile? StudentProfile { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
        = new List<OrderItem>();
}
// ======================================================
// OrderItemDto.cs
// ======================================================

namespace LMS.Shared.DTOs.Commerce.Orders.OrderItem;

public class OrderItemDto
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
}
// ======================================================
// OrderItemSummaryDto.cs
// ======================================================

namespace LMS.Shared.DTOs.Commerce.Orders.OrderItem;

public class OrderItemSummaryDto
{
    public long OrderItemId { get; set; }

    public long CourseId { get; set; }

    public string CourseTitle { get; set; } = string.Empty;

    public decimal TotalPrice { get; set; }
}
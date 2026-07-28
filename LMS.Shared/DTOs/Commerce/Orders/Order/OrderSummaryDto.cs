// ======================================================
// OrderSummaryDto.cs
// ======================================================

namespace LMS.Shared.DTOs.Commerce.Orders.Order;

public class OrderSummaryDto
{
    public long OrderId { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public string OrderStatus { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public int TotalItems { get; set; }
}
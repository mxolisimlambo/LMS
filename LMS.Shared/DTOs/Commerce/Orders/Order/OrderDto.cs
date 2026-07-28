// ======================================================
// OrderDto.cs
// ======================================================

namespace LMS.Shared.DTOs.Commerce.Orders.Order;

public class OrderDto
{
    public long OrderId { get; set; }

    public long StudentProfileId { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public decimal SubTotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public string OrderStatus { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
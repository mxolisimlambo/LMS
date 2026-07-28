// ======================================================
// UpdateOrderItemDto.cs
// ======================================================

using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Commerce.Orders.OrderItem;

public class UpdateOrderItemDto
{
    [Required]
    [Range(1, long.MaxValue)]
    public long OrderItemId { get; set; }
}
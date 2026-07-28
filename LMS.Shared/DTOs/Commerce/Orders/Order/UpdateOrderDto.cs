// ======================================================
// UpdateOrderDto.cs
// ======================================================

using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Commerce.Orders.Order;

public class UpdateOrderDto
{
    [Required]
    [Range(1, long.MaxValue)]
    public long OrderId { get; set; }

    [Required]
    [StringLength(50)]
    public string OrderStatus { get; set; } = string.Empty;
}
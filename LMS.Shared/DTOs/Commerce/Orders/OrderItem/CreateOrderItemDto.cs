// ======================================================
// CreateOrderItemDto.cs
// ======================================================

using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Commerce.Orders.OrderItem;

public class CreateOrderItemDto
{
    [Required]
    [Range(1, long.MaxValue)]
    public long OrderId { get; set; }

    [Required]
    [Range(1, long.MaxValue)]
    public long CourseId { get; set; }
}
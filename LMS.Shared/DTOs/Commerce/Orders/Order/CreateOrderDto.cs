// ======================================================
// CreateOrderDto.cs
// ======================================================

using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Commerce.Orders.Order;

public class CreateOrderDto
{
    [Required]
    [Range(1, long.MaxValue)]
    public long StudentProfileId { get; set; }

    [Required]
    [StringLength(10)]
    public string Currency { get; set; } = "ZAR";
}
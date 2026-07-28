using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Payments.Refund;

public class CreateRefundDto
{
    [Required]
    public long PaymentId { get; set; }

    [Required]
    public long StudentProfileId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal RefundAmount { get; set; }

    [Required]
    [StringLength(10)]
    public string Currency { get; set; } = "ZAR";

    [Required]
    [StringLength(500)]
    public string RefundReason { get; set; } = string.Empty;
}

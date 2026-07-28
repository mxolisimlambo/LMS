using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Payments.Refund;

public class UpdateRefundDto
{
    [Required]
    public long RefundId { get; set; }

    [Required]
    [StringLength(50)]
    public string RefundStatus { get; set; } = string.Empty;

    [StringLength(450)]
    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    [StringLength(500)]
    public string? RejectionReason { get; set; }

    [StringLength(150)]
    public string? GatewayRefundReference { get; set; }
}

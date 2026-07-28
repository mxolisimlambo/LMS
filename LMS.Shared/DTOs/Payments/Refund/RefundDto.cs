namespace LMS.Shared.DTOs.Payments.Refund;

public class RefundDto
{
    public long RefundId { get; set; }

    public long PaymentId { get; set; }

    public long StudentProfileId { get; set; }

    public string RefundReference { get; set; } = string.Empty;

    public decimal RefundAmount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string RefundReason { get; set; } = string.Empty;

    public string RefundStatus { get; set; } = string.Empty;

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? RejectionReason { get; set; }

    public string? GatewayRefundReference { get; set; }

    public DateTime RefundDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

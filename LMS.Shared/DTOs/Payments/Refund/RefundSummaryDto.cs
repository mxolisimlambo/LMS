namespace LMS.Shared.DTOs.Payments.Refund;

public class RefundSummaryDto
{
    public long RefundId { get; set; }

    public string RefundReference { get; set; } = string.Empty;

    public decimal RefundAmount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string RefundStatus { get; set; } = string.Empty;

    public DateTime RefundDate { get; set; }
}

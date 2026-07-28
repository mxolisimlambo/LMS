namespace LMS.Shared.DTOs.Payments.Payment;

public class PaymentSummaryDto
{
    public long PaymentId { get; set; }

    public string PaymentReference { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string PaymentStatus { get; set; } = string.Empty;

    public DateTime PaymentDate { get; set; }
}

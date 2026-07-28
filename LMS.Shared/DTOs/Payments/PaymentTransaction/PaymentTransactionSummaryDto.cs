namespace LMS.Shared.DTOs.Payments.PaymentTransaction;

public class PaymentTransactionSummaryDto
{
    public long PaymentTransactionId { get; set; }

    public string TransactionReference { get; set; } = string.Empty;

    public string GatewayName { get; set; } = string.Empty;

    public string TransactionType { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string TransactionStatus { get; set; } = string.Empty;

    public DateTime TransactionDate { get; set; }
}

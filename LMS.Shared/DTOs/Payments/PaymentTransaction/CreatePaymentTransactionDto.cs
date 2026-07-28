namespace LMS.Shared.DTOs.Payments.PaymentTransaction;

public class CreatePaymentTransactionDto
{
    public long PaymentId { get; set; }

    public long StudentProfileId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public string GatewayName { get; set; } = string.Empty;

    public string TransactionType { get; set; } = string.Empty;
}

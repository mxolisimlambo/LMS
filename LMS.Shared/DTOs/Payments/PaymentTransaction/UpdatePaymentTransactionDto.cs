namespace LMS.Shared.DTOs.Payments.PaymentTransaction;

public class UpdatePaymentTransactionDto
{
    public long PaymentTransactionId { get; set; }

    public string GatewayTransactionId { get; set; } = string.Empty;

    public string TransactionStatus { get; set; } = string.Empty;

    public string ResponseCode { get; set; } = string.Empty;

    public string ResponseMessage { get; set; } = string.Empty;

    public string? FailureReason { get; set; }

    public string? GatewayResponse { get; set; }
}

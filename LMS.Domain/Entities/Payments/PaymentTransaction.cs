using LMS.Domain.Entities.Students;

namespace LMS.Domain.Entities.Payments;

public class PaymentTransaction
{
    public long PaymentTransactionId { get; set; }

    public long PaymentId { get; set; }

    public long StudentProfileId { get; set; }

    public string TransactionReference { get; set; } = string.Empty;

    public string GatewayTransactionId { get; set; } = string.Empty;

    public string GatewayName { get; set; } = string.Empty;

    public string TransactionType { get; set; } = string.Empty;
    // Authorization
    // Capture
    // Sale
    // Refund
    // Void

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public string TransactionStatus { get; set; } = "Pending";
    // Pending
    // Processing
    // Success
    // Failed
    // Cancelled
    // Refunded

    public string ResponseCode { get; set; } = string.Empty;

    public string ResponseMessage { get; set; } = string.Empty;

    public string? FailureReason { get; set; }

    public string? GatewayResponse { get; set; }

    public DateTime TransactionDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Properties

    public Payment? Payment { get; set; }

    public StudentProfile? StudentProfile { get; set; }
}

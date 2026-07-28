using LMS.Domain.Entities.Students;

namespace LMS.Domain.Entities.Payments;

public class Refund
{
    public long RefundId { get; set; }

    public long PaymentId { get; set; }

    public long StudentProfileId { get; set; }

    public string RefundReference { get; set; } = string.Empty;

    public decimal RefundAmount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public string RefundReason { get; set; } = string.Empty;

    public string RefundStatus { get; set; } = "Pending";
    // Pending
    // Approved
    // Rejected
    // Processing
    // Completed
    // Cancelled

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? RejectionReason { get; set; }

    public string? GatewayRefundReference { get; set; }

    public DateTime RefundDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Properties

    public Payment? Payment { get; set; }

    public StudentProfile? StudentProfile { get; set; }
}

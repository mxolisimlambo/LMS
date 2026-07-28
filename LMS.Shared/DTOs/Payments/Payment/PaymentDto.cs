namespace LMS.Shared.DTOs.Payments.Payment;

public class PaymentDto
{
    public long PaymentId { get; set; }

    public long OrderId { get; set; }

    public long StudentProfileId { get; set; }

    public long PaymentMethodId { get; set; }

    public decimal Amount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string PaymentReference { get; set; } = string.Empty;

    public string PaymentStatus { get; set; } = string.Empty;

    public DateTime PaymentDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

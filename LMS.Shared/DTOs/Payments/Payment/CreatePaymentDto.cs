namespace LMS.Shared.DTOs.Payments.Payment;

public class CreatePaymentDto
{
    public long OrderId { get; set; }

    public long StudentProfileId { get; set; }

    public long PaymentMethodId { get; set; }

    public decimal Amount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = "ZAR";
}

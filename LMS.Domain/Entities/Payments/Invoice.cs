using LMS.Domain.Entities.Students;

namespace LMS.Domain.Entities.Payments;

public class Invoice
{
    public long InvoiceId { get; set; }

    public long PaymentId { get; set; }

    public long StudentProfileId { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;

    public DateTime InvoiceDate { get; set; }

    public decimal SubTotal { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public string BillingName { get; set; } = string.Empty;

    public string BillingEmail { get; set; } = string.Empty;

    public string? BillingPhoneNumber { get; set; }

    public string? BillingAddress { get; set; }

    public string? CompanyName { get; set; }

    public string? TaxNumber { get; set; }

    public string? PdfPath { get; set; }

    public bool IsPaid { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Properties

    public Payment? Payment { get; set; }

    public StudentProfile? StudentProfile { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Payments.Invoice;

public class UpdateInvoiceDto
{
    [Required]
    public long InvoiceId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal SubTotal { get; set; }

    [Range(0, double.MaxValue)]
    public decimal DiscountAmount { get; set; }

    [Range(0, double.MaxValue)]
    public decimal TaxAmount { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal TotalAmount { get; set; }

    [Required]
    [StringLength(10)]
    public string Currency { get; set; } = "ZAR";

    [Required]
    [StringLength(200)]
    public string BillingName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string BillingEmail { get; set; } = string.Empty;

    [Phone]
    [StringLength(50)]
    public string? BillingPhoneNumber { get; set; }

    [StringLength(500)]
    public string? BillingAddress { get; set; }

    [StringLength(200)]
    public string? CompanyName { get; set; }

    [StringLength(100)]
    public string? TaxNumber { get; set; }

    public bool IsPaid { get; set; }
}

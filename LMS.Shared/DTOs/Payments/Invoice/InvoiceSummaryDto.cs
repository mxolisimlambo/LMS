namespace LMS.Shared.DTOs.Payments.Invoice;

public class InvoiceSummaryDto
{
    public long InvoiceId { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public bool IsPaid { get; set; }

    public DateTime InvoiceDate { get; set; }
}

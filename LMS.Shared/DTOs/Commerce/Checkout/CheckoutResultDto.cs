namespace LMS.Shared.DTOs.Commerce.Checkout;

public class CheckoutResultDto
{
// ======================================================
// CHECKOUT RESULT
// ======================================================

public bool Success { get; set; }

public string Message { get; set; }
    = string.Empty;

// ======================================================
// CREATED ORDER
// ======================================================

public long OrderId { get; set; }

public string OrderNumber { get; set; }
    = string.Empty;

// ======================================================
// CREATED PAYMENT
// ======================================================

public long PaymentId { get; set; }

public string PaymentStatus { get; set; }
    = string.Empty;

// ======================================================
// FINANCIAL TOTAL
// ======================================================

public decimal TotalAmount { get; set; }

    public string Currency { get; set; }
        = string.Empty;
    
    public long InvoiceId { get; set; }

public string InvoiceNumber { get; set; } = string.Empty;

}

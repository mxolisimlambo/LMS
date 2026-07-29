using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Commerce.Checkout;

public class CheckoutDto
{
// ======================================================
// STUDENT PROFILE
// ======================================================

[Required]
[Range(1, long.MaxValue)]
public long StudentProfileId { get; set; }

// ======================================================
// PAYMENT METHOD
// ======================================================

[Required]
[Range(1, long.MaxValue)]
public long PaymentMethodId { get; set; }

// ======================================================
// CURRENCY
// ======================================================

[Required]
[StringLength(10)]
public string Currency { get; set; }
    = "ZAR";

}

namespace LMS.Shared.DTOs.Payments.PaymentMethod;

public class PaymentMethodSummaryDto
{
    public long PaymentMethodId { get; set; }

    public string MethodName { get; set; } = string.Empty;

    public string ProviderName { get; set; } = string.Empty;

    public string Currency { get; set; } = string.Empty;

    public bool IsDefault { get; set; }

    public bool IsActive { get; set; }
}

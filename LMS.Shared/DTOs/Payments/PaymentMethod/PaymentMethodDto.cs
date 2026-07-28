namespace LMS.Shared.DTOs.Payments.PaymentMethod;

public class PaymentMethodDto
{
    public long PaymentMethodId { get; set; }

    public string MethodName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ProviderName { get; set; } = string.Empty;

    public string ProviderCode { get; set; } = string.Empty;

    public string Currency { get; set; } = string.Empty;

    public bool SupportsRefunds { get; set; }

    public bool SupportsRecurringPayments { get; set; }

    public bool IsDefault { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

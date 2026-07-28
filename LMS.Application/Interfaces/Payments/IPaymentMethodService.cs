using LMS.Shared.DTOs.Payments.PaymentMethod;

namespace LMS.Application.Interfaces.Payments;

public interface IPaymentMethodService
{
    Task<bool> CreatePaymentMethodAsync(
        CreatePaymentMethodDto dto);

    Task<bool> UpdatePaymentMethodAsync(
        UpdatePaymentMethodDto dto);

    Task<bool> DeletePaymentMethodAsync(
        long paymentMethodId);

    Task<PaymentMethodDto?> GetPaymentMethodByIdAsync(
        long paymentMethodId);

    Task<IEnumerable<PaymentMethodSummaryDto>> GetAllPaymentMethodsAsync();

    Task<bool> ActivatePaymentMethodAsync(
        long paymentMethodId);

    Task<bool> DeactivatePaymentMethodAsync(
        long paymentMethodId);
}

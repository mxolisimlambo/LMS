using LMS.Shared.DTOs.Payments.Payment;

namespace LMS.Application.Interfaces.Payments;

public interface IPaymentService
{
    Task<bool> CreatePaymentAsync(CreatePaymentDto dto);

    Task<bool> UpdatePaymentAsync(UpdatePaymentDto dto);

    Task<bool> DeletePaymentAsync(long paymentId);

    Task<PaymentDto?> GetPaymentByIdAsync(long paymentId);

    Task<IEnumerable<PaymentSummaryDto>> GetPaymentsByStudentAsync(
        long studentProfileId);

    Task<IEnumerable<PaymentSummaryDto>> GetPaymentsByOrderAsync(
        long orderId);

    Task<IEnumerable<PaymentSummaryDto>> GetAllPaymentsAsync();

    Task<bool> ProcessPaymentAsync(long paymentId);

    Task<bool> CancelPaymentAsync(long paymentId);

    Task<bool> ExistsAsync(long paymentId);
}

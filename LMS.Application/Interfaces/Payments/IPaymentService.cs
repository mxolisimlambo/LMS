using LMS.Shared.DTOs.Payments.Payment;
using LMS.Domain.Entities.Payments;

namespace LMS.Application.Interfaces.Payments;

public interface IPaymentService
{  // ======================================================
    // CREATE PAYMENT
    // ======================================================

    Task<Payment> CreatePaymentAsync(
        long orderId,
        long studentProfileId,
        long paymentMethodId,
        decimal amount,
        decimal discountAmount,
        decimal taxAmount,
        decimal totalAmount,
        string currency);

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
    // ======================================================
// VALIDATE PAYMENT METHOD
// ======================================================

Task<bool> ValidatePaymentMethodAsync(
    long paymentMethodId);
}

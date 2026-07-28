using LMS.Shared.DTOs.Payments.PaymentTransaction;

namespace LMS.Application.Interfaces.Payments;

public interface IPaymentTransactionService
{
    Task<bool> CreateTransactionAsync(
        CreatePaymentTransactionDto dto);

    Task<bool> UpdateTransactionAsync(
        UpdatePaymentTransactionDto dto);

    Task<bool> DeleteTransactionAsync(
        long paymentTransactionId);

    Task<PaymentTransactionDto?> GetTransactionByIdAsync(
        long paymentTransactionId);

    Task<IEnumerable<PaymentTransactionSummaryDto>>
        GetTransactionsByPaymentAsync(
            long paymentId);

    Task<IEnumerable<PaymentTransactionSummaryDto>>
        GetTransactionsByStudentAsync(
            long studentProfileId);

    Task<IEnumerable<PaymentTransactionSummaryDto>>
        GetAllTransactionsAsync();

    Task<bool> ExistsAsync(
        long paymentTransactionId);
}

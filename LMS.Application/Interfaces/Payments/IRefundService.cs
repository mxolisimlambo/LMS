using LMS.Shared.DTOs.Payments.Refund;

namespace LMS.Application.Interfaces.Payments;

public interface IRefundService
{
    Task<bool> CreateRefundAsync(
        CreateRefundDto dto);

    Task<bool> UpdateRefundAsync(
        UpdateRefundDto dto);

    Task<bool> DeleteRefundAsync(
        long refundId);

    Task<RefundDto?> GetRefundByIdAsync(
        long refundId);

    Task<IEnumerable<RefundSummaryDto>>
        GetRefundsByPaymentAsync(
            long paymentId);

    Task<IEnumerable<RefundSummaryDto>>
        GetRefundsByStudentAsync(
            long studentProfileId);

    Task<IEnumerable<RefundSummaryDto>>
        GetAllRefundsAsync();

    Task<bool> ApproveRefundAsync(
        long refundId);

    Task<bool> RejectRefundAsync(
        long refundId);

    Task<bool> ExistsAsync(
        long refundId);
}

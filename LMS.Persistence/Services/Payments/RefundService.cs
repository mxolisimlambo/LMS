using LMS.Application.Interfaces.Payments;
using LMS.Domain.Entities.Payments;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Payments.Refund;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Payments;

public class RefundService : IRefundService
{
    private readonly ApplicationDbContext _context;

    public RefundService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateRefundAsync(
        CreateRefundDto dto)
    {
        var refund = new Refund
        {
            PaymentId = dto.PaymentId,
            StudentProfileId = dto.StudentProfileId,

            RefundReference = $"REF{DateTime.UtcNow.Ticks}",

            RefundAmount = dto.RefundAmount,

            Currency = dto.Currency,

            RefundReason = dto.RefundReason,

            RefundStatus = "Pending",

            RefundDate = DateTime.UtcNow,

            CreatedDate = DateTime.UtcNow,

            UpdatedDate = null,

            IsDeleted = false
        };

        _context.Refunds.Add(refund);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateRefundAsync(
        UpdateRefundDto dto)
    {
        var refund = await _context.Refunds
            .FirstOrDefaultAsync(x =>
                x.RefundId == dto.RefundId);

        if (refund == null)
            return false;

        refund.RefundStatus = dto.RefundStatus;
        refund.ApprovedBy = dto.ApprovedBy;
        refund.ApprovedDate = dto.ApprovedDate;
        refund.RejectionReason = dto.RejectionReason;
        refund.GatewayRefundReference = dto.GatewayRefundReference;

        refund.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteRefundAsync(
        long refundId)
    {
        var refund = await _context.Refunds
            .FirstOrDefaultAsync(x =>
                x.RefundId == refundId);

        if (refund == null)
            return false;

        refund.IsDeleted = true;
        refund.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<RefundDto?> GetRefundByIdAsync(
        long refundId)
    {
        return await _context.Refunds
            .Where(x => x.RefundId == refundId)
            .Select(x => new RefundDto
            {
                RefundId = x.RefundId,
                PaymentId = x.PaymentId,
                StudentProfileId = x.StudentProfileId,
                RefundReference = x.RefundReference,
                RefundAmount = x.RefundAmount,
                Currency = x.Currency,
                RefundReason = x.RefundReason,
                RefundStatus = x.RefundStatus,
                ApprovedBy = x.ApprovedBy,
                ApprovedDate = x.ApprovedDate,
                RejectionReason = x.RejectionReason,
                GatewayRefundReference = x.GatewayRefundReference,
                RefundDate = x.RefundDate,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<RefundSummaryDto>>
        GetRefundsByPaymentAsync(
            long paymentId)
    {
        return await _context.Refunds
            .Where(x =>
                x.PaymentId == paymentId &&
                !x.IsDeleted)
            .OrderByDescending(x => x.RefundDate)
            .Select(x => new RefundSummaryDto
            {
                RefundId = x.RefundId,
                RefundReference = x.RefundReference,
                RefundAmount = x.RefundAmount,
                Currency = x.Currency,
                RefundStatus = x.RefundStatus,
                RefundDate = x.RefundDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<RefundSummaryDto>>
        GetRefundsByStudentAsync(
            long studentProfileId)
    {
        return await _context.Refunds
            .Where(x =>
                x.StudentProfileId == studentProfileId &&
                !x.IsDeleted)
            .OrderByDescending(x => x.RefundDate)
            .Select(x => new RefundSummaryDto
            {
                RefundId = x.RefundId,
                RefundReference = x.RefundReference,
                RefundAmount = x.RefundAmount,
                Currency = x.Currency,
                RefundStatus = x.RefundStatus,
                RefundDate = x.RefundDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<RefundSummaryDto>>
        GetAllRefundsAsync()
    {
        return await _context.Refunds
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.RefundDate)
            .Select(x => new RefundSummaryDto
            {
                RefundId = x.RefundId,
                RefundReference = x.RefundReference,
                RefundAmount = x.RefundAmount,
                Currency = x.Currency,
                RefundStatus = x.RefundStatus,
                RefundDate = x.RefundDate
            })
            .ToListAsync();
    }

    public async Task<bool> ApproveRefundAsync(
        long refundId)
    {
        var refund = await _context.Refunds
            .FirstOrDefaultAsync(x =>
                x.RefundId == refundId);

        if (refund == null)
            return false;

        refund.RefundStatus = "Approved";
        refund.ApprovedDate = DateTime.UtcNow;
        refund.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RejectRefundAsync(
        long refundId)
    {
        var refund = await _context.Refunds
            .FirstOrDefaultAsync(x =>
                x.RefundId == refundId);

        if (refund == null)
            return false;

        refund.RefundStatus = "Rejected";
        refund.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(
        long refundId)
    {
        return await _context.Refunds
            .AnyAsync(x =>
                x.RefundId == refundId &&
                !x.IsDeleted);
    }
}

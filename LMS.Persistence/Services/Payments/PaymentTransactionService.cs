using LMS.Application.Interfaces.Payments;
using LMS.Domain.Entities.Payments;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Payments.PaymentTransaction;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Payments;

public class PaymentTransactionService
    : IPaymentTransactionService
{
    private readonly ApplicationDbContext _context;

    public PaymentTransactionService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateTransactionAsync(
        CreatePaymentTransactionDto dto)
    {
        var transaction = new PaymentTransaction
        {
            PaymentId = dto.PaymentId,
            StudentProfileId = dto.StudentProfileId,

            TransactionReference = $"TRN{DateTime.UtcNow.Ticks}",

            GatewayTransactionId = string.Empty,

            GatewayName = dto.GatewayName,

            TransactionType = dto.TransactionType,

            Amount = dto.Amount,

            Currency = dto.Currency,

            TransactionStatus = "Pending",

            TransactionDate = DateTime.UtcNow,

            ResponseCode = string.Empty,

            ResponseMessage = string.Empty,

            FailureReason = null,

            GatewayResponse = null,

            CreatedDate = DateTime.UtcNow,



            IsDeleted = false
        };

        _context.PaymentTransactions.Add(transaction);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateTransactionAsync(
        UpdatePaymentTransactionDto dto)
    {
        var transaction = await _context.PaymentTransactions
            .FirstOrDefaultAsync(x =>
                x.PaymentTransactionId ==
                dto.PaymentTransactionId);

        if (transaction == null)
            return false;

        transaction.GatewayTransactionId =
            dto.GatewayTransactionId;

        transaction.TransactionStatus =
            dto.TransactionStatus;

        transaction.ResponseCode =
            dto.ResponseCode;

        transaction.ResponseMessage =
            dto.ResponseMessage;

        transaction.FailureReason =
            dto.FailureReason;

        transaction.GatewayResponse =
            dto.GatewayResponse;

        //transaction.UpdatedDate =
        //  DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteTransactionAsync(
        long paymentTransactionId)
    {
        var transaction = await _context.PaymentTransactions
            .FirstOrDefaultAsync(x =>
                x.PaymentTransactionId ==
                paymentTransactionId);

        if (transaction == null)
            return false;

        transaction.IsDeleted = true;

        transaction.CreatedDate =
            DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<PaymentTransactionDto?>
        GetTransactionByIdAsync(
            long paymentTransactionId)
    {
        return await _context.PaymentTransactions
            .Where(x =>
                x.PaymentTransactionId ==
                paymentTransactionId)
            .Select(x => new PaymentTransactionDto
            {
                PaymentTransactionId =
                    x.PaymentTransactionId,

                PaymentId = x.PaymentId,

                StudentProfileId =
                    x.StudentProfileId,

                TransactionReference =
                    x.TransactionReference,

                GatewayTransactionId =
                    x.GatewayTransactionId,

                GatewayName =
                    x.GatewayName,

                TransactionType =
                    x.TransactionType,

                Amount =
                    x.Amount,

                Currency =
                    x.Currency,

                TransactionStatus =
                    x.TransactionStatus,

                ResponseCode =
                    x.ResponseCode,

                ResponseMessage =
                    x.ResponseMessage,

                FailureReason =
                    x.FailureReason,

                GatewayResponse =
                    x.GatewayResponse,

                TransactionDate =
                    x.TransactionDate,

                CreatedDate =
                    x.CreatedDate,

                IsDeleted =
                    x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PaymentTransactionSummaryDto>>
        GetTransactionsByPaymentAsync(
            long paymentId)
    {
        return await _context.PaymentTransactions
            .Where(x =>
                x.PaymentId == paymentId &&
                !x.IsDeleted)
            .OrderByDescending(x =>
                x.TransactionDate)
            .Select(x => new PaymentTransactionSummaryDto
            {
                PaymentTransactionId =
                    x.PaymentTransactionId,

                TransactionReference =
                    x.TransactionReference,

                GatewayName =
                    x.GatewayName,

                TransactionType =
                    x.TransactionType,

                Amount =
                    x.Amount,

                TransactionStatus =
                    x.TransactionStatus,

                TransactionDate =
                    x.TransactionDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PaymentTransactionSummaryDto>>
        GetTransactionsByStudentAsync(
            long studentProfileId)
    {
        return await _context.PaymentTransactions
            .Where(x =>
                x.StudentProfileId ==
                studentProfileId &&
                !x.IsDeleted)
            .OrderByDescending(x =>
                x.TransactionDate)
            .Select(x => new PaymentTransactionSummaryDto
            {
                PaymentTransactionId =
                    x.PaymentTransactionId,

                TransactionReference =
                    x.TransactionReference,

                GatewayName =
                    x.GatewayName,

                TransactionType =
                    x.TransactionType,

                Amount =
                    x.Amount,

                TransactionStatus =
                    x.TransactionStatus,

                TransactionDate =
                    x.TransactionDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PaymentTransactionSummaryDto>>
        GetAllTransactionsAsync()
    {
        return await _context.PaymentTransactions
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x =>
                x.TransactionDate)
            .Select(x => new PaymentTransactionSummaryDto
            {
                PaymentTransactionId =
                    x.PaymentTransactionId,

                TransactionReference =
                    x.TransactionReference,

                GatewayName =
                    x.GatewayName,

                TransactionType =
                    x.TransactionType,

                Amount =
                    x.Amount,

                TransactionStatus =
                    x.TransactionStatus,

                TransactionDate =
                    x.TransactionDate
            })
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(
        long paymentTransactionId)
    {
        return await _context.PaymentTransactions
            .AnyAsync(x =>
                x.PaymentTransactionId ==
                paymentTransactionId &&
                !x.IsDeleted);
    }
}

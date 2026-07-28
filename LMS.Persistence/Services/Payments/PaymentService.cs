using LMS.Application.Interfaces.Payments;
using LMS.Domain.Entities.Payments;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Payments.Payment;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Payments;

public class PaymentService : IPaymentService
{
    private readonly ApplicationDbContext _context;

    public PaymentService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreatePaymentAsync(
        CreatePaymentDto dto)
    {
        var payment = new Payment
        {
            OrderId = dto.OrderId,
            StudentProfileId = dto.StudentProfileId,
            PaymentMethodId = dto.PaymentMethodId,

            PaymentReference = $"PAY{DateTime.UtcNow.Ticks}",

            Amount = dto.Amount,
            DiscountAmount = dto.DiscountAmount,
            TaxAmount = dto.TaxAmount,
            TotalAmount = dto.TotalAmount,

            Currency = dto.Currency,

            PaymentStatus = "Pending",

            PaymentDate = DateTime.UtcNow,

            CreatedDate = DateTime.UtcNow,

            UpdatedDate = null,

            IsDeleted = false
        };

        _context.Payments.Add(payment);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdatePaymentAsync(
        UpdatePaymentDto dto)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(x =>
                x.PaymentId == dto.PaymentId);

        if (payment == null)
            return false;

        payment.PaymentMethodId = dto.PaymentMethodId;

        payment.Amount = dto.Amount;

        payment.DiscountAmount = dto.DiscountAmount;

        payment.TaxAmount = dto.TaxAmount;

        payment.TotalAmount = dto.TotalAmount;

        payment.Currency = dto.Currency;

        payment.PaymentStatus = dto.PaymentStatus;

        payment.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletePaymentAsync(
        long paymentId)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(x =>
                x.PaymentId == paymentId);

        if (payment == null)
            return false;

        payment.IsDeleted = true;

        payment.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<PaymentDto?> GetPaymentByIdAsync(
        long paymentId)
    {
        return await _context.Payments
            .Where(x => x.PaymentId == paymentId)
            .Select(x => new PaymentDto
            {
                PaymentId = x.PaymentId,
                OrderId = x.OrderId,
                StudentProfileId = x.StudentProfileId,
                PaymentMethodId = x.PaymentMethodId,
                PaymentReference = x.PaymentReference,
                Amount = x.Amount,
                DiscountAmount = x.DiscountAmount,
                TaxAmount = x.TaxAmount,
                TotalAmount = x.TotalAmount,
                Currency = x.Currency,
                PaymentStatus = x.PaymentStatus,
                PaymentDate = x.PaymentDate,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<PaymentSummaryDto>>
    GetPaymentsByStudentAsync(
        long studentProfileId)
    {
        return await _context.Payments
            .Where(x =>
                x.StudentProfileId == studentProfileId &&
                !x.IsDeleted)
            .OrderByDescending(x => x.PaymentDate)
            .Select(x => new PaymentSummaryDto
            {
                PaymentId = x.PaymentId,
                PaymentReference = x.PaymentReference,
                TotalAmount = x.TotalAmount,
                Currency = x.Currency,
                PaymentStatus = x.PaymentStatus,
                PaymentDate = x.PaymentDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PaymentSummaryDto>>
        GetPaymentsByOrderAsync(
            long orderId)
    {
        return await _context.Payments
            .Where(x =>
                x.OrderId == orderId &&
                !x.IsDeleted)
            .OrderByDescending(x => x.PaymentDate)
            .Select(x => new PaymentSummaryDto
            {
                PaymentId = x.PaymentId,
                PaymentReference = x.PaymentReference,
                TotalAmount = x.TotalAmount,
                Currency = x.Currency,
                PaymentStatus = x.PaymentStatus,
                PaymentDate = x.PaymentDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PaymentSummaryDto>>
        GetAllPaymentsAsync()
    {
        return await _context.Payments
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.PaymentDate)
            .Select(x => new PaymentSummaryDto
            {
                PaymentId = x.PaymentId,
                PaymentReference = x.PaymentReference,
                TotalAmount = x.TotalAmount,
                Currency = x.Currency,
                PaymentStatus = x.PaymentStatus,
                PaymentDate = x.PaymentDate
            })
            .ToListAsync();
    }

    public async Task<bool> ProcessPaymentAsync(
        long paymentId)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(x =>
                x.PaymentId == paymentId);

        if (payment == null)
            return false;

        payment.PaymentStatus = "Completed";
        payment.PaymentDate = DateTime.UtcNow;
        payment.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> CancelPaymentAsync(
        long paymentId)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(x =>
                x.PaymentId == paymentId);

        if (payment == null)
            return false;

        payment.PaymentStatus = "Cancelled";
        payment.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(
        long paymentId)
    {
        return await _context.Payments
            .AnyAsync(x =>
                x.PaymentId == paymentId &&
                !x.IsDeleted);
    }
}

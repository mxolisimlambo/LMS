using LMS.Application.Interfaces.Payments;
using LMS.Domain.Entities.Payments;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Payments.PaymentMethod;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Payments;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly ApplicationDbContext _context;

    public PaymentMethodService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreatePaymentMethodAsync(
        CreatePaymentMethodDto dto)
    {
        var exists = await _context.PaymentMethods
            .AnyAsync(x => x.MethodName == dto.MethodName);

        if (exists)
            return false;

        var paymentMethod = new PaymentMethod
        {
            MethodName = dto.MethodName,
            Description = dto.Description,
            ProviderName = dto.ProviderName,
            ProviderCode = dto.ProviderCode,
            Currency = dto.Currency,
            SupportsRefunds = dto.SupportsRefunds,
            SupportsRecurringPayments = dto.SupportsRecurringPayments,
            IsDefault = dto.IsDefault,
            IsActive = dto.IsActive,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = null,
            IsDeleted = false
        };

        _context.PaymentMethods.Add(paymentMethod);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdatePaymentMethodAsync(
        UpdatePaymentMethodDto dto)
    {
        var paymentMethod = await _context.PaymentMethods
            .FirstOrDefaultAsync(x =>
                x.PaymentMethodId == dto.PaymentMethodId);

        if (paymentMethod == null)
            return false;

        paymentMethod.MethodName = dto.MethodName;
        paymentMethod.Description = dto.Description;
        paymentMethod.ProviderName = dto.ProviderName;
        paymentMethod.ProviderCode = dto.ProviderCode;
        paymentMethod.Currency = dto.Currency;
        paymentMethod.SupportsRefunds = dto.SupportsRefunds;
        paymentMethod.SupportsRecurringPayments = dto.SupportsRecurringPayments;
        paymentMethod.IsDefault = dto.IsDefault;
        paymentMethod.IsActive = dto.IsActive;
        paymentMethod.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletePaymentMethodAsync(
        long paymentMethodId)
    {
        var paymentMethod = await _context.PaymentMethods
            .FirstOrDefaultAsync(x =>
                x.PaymentMethodId == paymentMethodId);

        if (paymentMethod == null)
            return false;

        paymentMethod.IsDeleted = true;
        paymentMethod.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<PaymentMethodDto?> GetPaymentMethodByIdAsync(
        long paymentMethodId)
    {
        return await _context.PaymentMethods
            .Where(x =>
                x.PaymentMethodId == paymentMethodId)
            .Select(x => new PaymentMethodDto
            {
                PaymentMethodId = x.PaymentMethodId,
                MethodName = x.MethodName,
                Description = x.Description,
                ProviderName = x.ProviderName,
                ProviderCode = x.ProviderCode,
                Currency = x.Currency,
                SupportsRefunds = x.SupportsRefunds,
                SupportsRecurringPayments = x.SupportsRecurringPayments,
                IsDefault = x.IsDefault,
                IsActive = x.IsActive,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PaymentMethodSummaryDto>>
        GetAllPaymentMethodsAsync()
    {
        return await _context.PaymentMethods
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.MethodName)
            .Select(x => new PaymentMethodSummaryDto
            {
                PaymentMethodId = x.PaymentMethodId,
                MethodName = x.MethodName,
                ProviderName = x.ProviderName,
                Currency = x.Currency,
                IsDefault = x.IsDefault,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }

    public async Task<bool> ActivatePaymentMethodAsync(
        long paymentMethodId)
    {
        var paymentMethod = await _context.PaymentMethods
            .FirstOrDefaultAsync(x =>
                x.PaymentMethodId == paymentMethodId);

        if (paymentMethod == null)
            return false;

        paymentMethod.IsActive = true;
        paymentMethod.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeactivatePaymentMethodAsync(
        long paymentMethodId)
    {
        var paymentMethod = await _context.PaymentMethods
            .FirstOrDefaultAsync(x =>
                x.PaymentMethodId == paymentMethodId);

        if (paymentMethod == null)
            return false;

        paymentMethod.IsActive = false;
        paymentMethod.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }
}

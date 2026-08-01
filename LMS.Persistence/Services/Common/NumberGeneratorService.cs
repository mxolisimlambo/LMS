using LMS.Application.Interfaces.Common;
using LMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Common;

public class NumberGeneratorService
    : INumberGeneratorService
{
    private readonly ApplicationDbContext _context;

    public NumberGeneratorService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> GenerateOrderNumberAsync()
    {
        var count =
            await _context.Orders.CountAsync() + 1;

        return $"ORD-{DateTime.UtcNow:yyyyMMdd}-{count:D6}";
    }

    public async Task<string> GenerateInvoiceNumberAsync()
    {
        var count =
            await _context.Invoices.CountAsync() + 1;

        return $"INV-{DateTime.UtcNow:yyyyMMdd}-{count:D6}";
    }

    public async Task<string> GeneratePaymentReferenceAsync()
    {
        var count =
            await _context.Payments.CountAsync() + 1;

        return $"PAY-{DateTime.UtcNow:yyyyMMdd}-{count:D6}";
    }
}
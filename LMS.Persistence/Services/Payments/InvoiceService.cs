using LMS.Application.Interfaces.Payments;
using LMS.Domain.Entities.Payments;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Payments.Invoice;
using LMS.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Payments;

public class InvoiceService : IInvoiceService
{
    private readonly ApplicationDbContext _context;

    public InvoiceService(
        ApplicationDbContext context)
    {
        _context = context;
    }
public async Task<Invoice> CreateInvoiceAsync(
    long paymentId)
{
    var payment = await _context.Payments
        .Include(x => x.Order)
        .FirstOrDefaultAsync(x =>
            x.PaymentId == paymentId &&
            !x.IsDeleted);

    if (payment == null)
        throw new Exception("Payment not found.");

    var invoice = new Invoice
    {
        PaymentId = payment.PaymentId,

        InvoiceNumber =
            $"INV-{DateTime.UtcNow:yyyyMMddHHmmss}",

        InvoiceDate =
            DateTime.UtcNow,

        TotalAmount =
            payment.TotalAmount,

        Currency =
            payment.Currency,

       // InvoiceStatus =
         //   "Issued",

        CreatedDate =
            DateTime.UtcNow,

        UpdatedDate =
            null,

        IsDeleted =
            false
    };

    _context.Invoices.Add(
        invoice);

    await _context.SaveChangesAsync();

    return invoice;
}

    public async Task<bool> UpdateInvoiceAsync(
        UpdateInvoiceDto dto)
    {
        var invoice = await _context.Invoices
            .FirstOrDefaultAsync(x =>
                x.InvoiceId == dto.InvoiceId);

        if (invoice == null)
            return false;

        invoice.SubTotal = dto.SubTotal;
        invoice.DiscountAmount = dto.DiscountAmount;
        invoice.TaxAmount = dto.TaxAmount;
        invoice.TotalAmount = dto.TotalAmount;
        invoice.Currency = dto.Currency;

        invoice.BillingName = dto.BillingName;
        invoice.BillingEmail = dto.BillingEmail;
        invoice.BillingPhoneNumber = dto.BillingPhoneNumber;
        invoice.BillingAddress = dto.BillingAddress;
        invoice.CompanyName = dto.CompanyName;
        invoice.TaxNumber = dto.TaxNumber;

        invoice.IsPaid = dto.IsPaid;

        invoice.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteInvoiceAsync(
        long invoiceId)
    {
        var invoice = await _context.Invoices
            .FirstOrDefaultAsync(x =>
                x.InvoiceId == invoiceId);

        if (invoice == null)
            return false;

        invoice.IsDeleted = true;
        invoice.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<InvoiceDto?> GetInvoiceByIdAsync(
        long invoiceId)
    {
        return await _context.Invoices
            .Where(x =>
                x.InvoiceId == invoiceId)
            .Select(x => new InvoiceDto
            {
                InvoiceId = x.InvoiceId,
                PaymentId = x.PaymentId,
                StudentProfileId = x.StudentProfileId,
                InvoiceNumber = x.InvoiceNumber,
                InvoiceDate = x.InvoiceDate,

                SubTotal = x.SubTotal,
                DiscountAmount = x.DiscountAmount,
                TaxAmount = x.TaxAmount,
                TotalAmount = x.TotalAmount,

                Currency = x.Currency,

                BillingName = x.BillingName,
                BillingEmail = x.BillingEmail,
                BillingPhoneNumber = x.BillingPhoneNumber,
                BillingAddress = x.BillingAddress,
                CompanyName = x.CompanyName,
                TaxNumber = x.TaxNumber,

                PdfPath = x.PdfPath,

                IsPaid = x.IsPaid,

                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,

                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<InvoiceSummaryDto>>
        GetInvoicesByStudentAsync(
            long studentProfileId)
    {
        return await _context.Invoices
            .Where(x =>
                x.StudentProfileId == studentProfileId &&
                !x.IsDeleted)
            .OrderByDescending(x => x.InvoiceDate)
            .Select(x => new InvoiceSummaryDto
            {
                InvoiceId = x.InvoiceId,
                InvoiceNumber = x.InvoiceNumber,
                TotalAmount = x.TotalAmount,
                Currency = x.Currency,
                IsPaid = x.IsPaid,
                InvoiceDate = x.InvoiceDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<InvoiceSummaryDto>>
        GetInvoicesByPaymentAsync(
            long paymentId)
    {
        return await _context.Invoices
            .Where(x =>
                x.PaymentId == paymentId &&
                !x.IsDeleted)
            .OrderByDescending(x => x.InvoiceDate)
            .Select(x => new InvoiceSummaryDto
            {
                InvoiceId = x.InvoiceId,
                InvoiceNumber = x.InvoiceNumber,
                TotalAmount = x.TotalAmount,
                Currency = x.Currency,
                IsPaid = x.IsPaid,
                InvoiceDate = x.InvoiceDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<InvoiceSummaryDto>>
        GetAllInvoicesAsync()
    {
        return await _context.Invoices
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.InvoiceDate)
            .Select(x => new InvoiceSummaryDto
            {
                InvoiceId = x.InvoiceId,
                InvoiceNumber = x.InvoiceNumber,
                TotalAmount = x.TotalAmount,
                Currency = x.Currency,
                IsPaid = x.IsPaid,
                InvoiceDate = x.InvoiceDate
            })
            .ToListAsync();
    }

    public async Task<bool> GenerateInvoiceAsync(
        long paymentId)
    {
        var invoice = await _context.Invoices
            .FirstOrDefaultAsync(x =>
                x.PaymentId == paymentId);

        if (invoice == null)
            return false;

        invoice.PdfPath =
            $"Invoices/{invoice.InvoiceNumber}.pdf";

        invoice.UpdatedDate =
            DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(
        long invoiceId)
    {
        return await _context.Invoices
            .AnyAsync(x =>
                x.InvoiceId == invoiceId &&
                !x.IsDeleted);
    }
}

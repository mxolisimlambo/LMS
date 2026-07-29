using LMS.Shared.DTOs.Payments.Invoice;
using LMS.Domain.Entities.Payments;   
namespace LMS.Application.Interfaces.Payments;

public interface IInvoiceService
{
    Task<Invoice> CreateInvoiceAsync(
    long paymentId);

    Task<bool> UpdateInvoiceAsync(
        UpdateInvoiceDto dto);

    Task<bool> DeleteInvoiceAsync(
        long invoiceId);

    Task<InvoiceDto?> GetInvoiceByIdAsync(
        long invoiceId);

    Task<IEnumerable<InvoiceSummaryDto>>
        GetInvoicesByStudentAsync(
            long studentProfileId);

    Task<IEnumerable<InvoiceSummaryDto>>
        GetInvoicesByPaymentAsync(
            long paymentId);

    Task<IEnumerable<InvoiceSummaryDto>>
        GetAllInvoicesAsync();

    Task<bool> GenerateInvoiceAsync(
        long paymentId);

    Task<bool> ExistsAsync(
        long invoiceId);
}

using LMS.Shared.DTOs.Payments.Invoice;

namespace LMS.Application.Interfaces.Payments;

public interface IInvoiceService
{
    Task<bool> CreateInvoiceAsync(
        CreateInvoiceDto dto);

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

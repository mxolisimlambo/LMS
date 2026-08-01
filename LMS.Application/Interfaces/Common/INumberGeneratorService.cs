namespace LMS.Application.Interfaces.Common;

public interface INumberGeneratorService
{
    Task<string> GenerateOrderNumberAsync();

    Task<string> GenerateInvoiceNumberAsync();

    Task<string> GeneratePaymentReferenceAsync();
}
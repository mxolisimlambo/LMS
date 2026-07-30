using LMS.Application.Interfaces.Payments;
using LMS.Shared.DTOs.Payments.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Payments;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(
        IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInvoices()
    {
        var result = await _invoiceService
            .GetAllInvoicesAsync();

        return Ok(result);
    }

    [HttpGet("{invoiceId:long}")]
    public async Task<IActionResult> GetInvoiceById(
        long invoiceId)
    {
        var result = await _invoiceService
            .GetInvoiceByIdAsync(invoiceId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("student/{studentProfileId:long}")]
    public async Task<IActionResult> GetInvoicesByStudent(
        long studentProfileId)
    {
        var result = await _invoiceService
            .GetInvoicesByStudentAsync(studentProfileId);

        return Ok(result);
    }

    [HttpGet("payment/{paymentId:long}")]
    public async Task<IActionResult> GetInvoicesByPayment(
        long paymentId)
    {
        var result = await _invoiceService
            .GetInvoicesByPaymentAsync(paymentId);

        return Ok(result);
    }

   [HttpPost("{paymentId:long}")]
public async Task<IActionResult> CreateInvoice(
    long paymentId)
{
    var invoice = await _invoiceService
        .CreateInvoiceAsync(paymentId);

    return Ok(invoice);
}

    [HttpPut]
    public async Task<IActionResult> UpdateInvoice(
        UpdateInvoiceDto dto)
    {
        var result = await _invoiceService
            .UpdateInvoiceAsync(dto);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpDelete("{invoiceId:long}")]
    public async Task<IActionResult> DeleteInvoice(
        long invoiceId)
    {
        var result = await _invoiceService
            .DeleteInvoiceAsync(invoiceId);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpPut("generate/{paymentId:long}")]
    public async Task<IActionResult> GenerateInvoice(
        long paymentId)
    {
        var result = await _invoiceService
            .GenerateInvoiceAsync(paymentId);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpGet("exists/{invoiceId:long}")]
    public async Task<IActionResult> Exists(
        long invoiceId)
    {
        var result = await _invoiceService
            .ExistsAsync(invoiceId);

        return Ok(result);
    }
}

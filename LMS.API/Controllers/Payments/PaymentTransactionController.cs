using LMS.Application.Interfaces.Payments;
using LMS.Shared.DTOs.Payments.PaymentTransaction;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Payments;

[ApiController]
[Route("api/[controller]")]
public class PaymentTransactionController : ControllerBase
{
    private readonly IPaymentTransactionService _paymentTransactionService;

    public PaymentTransactionController(
        IPaymentTransactionService paymentTransactionService)
    {
        _paymentTransactionService = paymentTransactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var result = await _paymentTransactionService
            .GetAllTransactionsAsync();

        return Ok(result);
    }

    [HttpGet("{paymentTransactionId:long}")]
    public async Task<IActionResult> GetTransactionById(
        long paymentTransactionId)
    {
        var result = await _paymentTransactionService
            .GetTransactionByIdAsync(paymentTransactionId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("payment/{paymentId:long}")]
    public async Task<IActionResult> GetTransactionsByPayment(
        long paymentId)
    {
        var result = await _paymentTransactionService
            .GetTransactionsByPaymentAsync(paymentId);

        return Ok(result);
    }

    [HttpGet("student/{studentProfileId:long}")]
    public async Task<IActionResult> GetTransactionsByStudent(
        long studentProfileId)
    {
        var result = await _paymentTransactionService
            .GetTransactionsByStudentAsync(studentProfileId);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction(
        CreatePaymentTransactionDto dto)
    {
        var result = await _paymentTransactionService
            .CreateTransactionAsync(dto);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTransaction(
        UpdatePaymentTransactionDto dto)
    {
        var result = await _paymentTransactionService
            .UpdateTransactionAsync(dto);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpDelete("{paymentTransactionId:long}")]
    public async Task<IActionResult> DeleteTransaction(
        long paymentTransactionId)
    {
        var result = await _paymentTransactionService
            .DeleteTransactionAsync(paymentTransactionId);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpGet("exists/{paymentTransactionId:long}")]
    public async Task<IActionResult> Exists(
        long paymentTransactionId)
    {
        var result = await _paymentTransactionService
            .ExistsAsync(paymentTransactionId);

        return Ok(result);
    }
}

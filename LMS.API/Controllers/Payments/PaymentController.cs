using LMS.Application.Interfaces.Payments;
using LMS.Shared.DTOs.Payments.Payment;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Payments;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(
        IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPayments()
    {
        var result = await _paymentService
            .GetAllPaymentsAsync();

        return Ok(result);
    }

    [HttpGet("{paymentId:long}")]
    public async Task<IActionResult> GetPaymentById(
        long paymentId)
    {
        var result = await _paymentService
            .GetPaymentByIdAsync(paymentId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("student/{studentProfileId:long}")]
    public async Task<IActionResult> GetPaymentsByStudent(
        long studentProfileId)
    {
        var result = await _paymentService
            .GetPaymentsByStudentAsync(studentProfileId);

        return Ok(result);
    }

    [HttpGet("order/{orderId:long}")]
    public async Task<IActionResult> GetPaymentsByOrder(
        long orderId)
    {
        var result = await _paymentService
            .GetPaymentsByOrderAsync(orderId);

        return Ok(result);
    }

    

    [HttpPut]
    public async Task<IActionResult> UpdatePayment(
        UpdatePaymentDto dto)
    {
        var result = await _paymentService
            .UpdatePaymentAsync(dto);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpDelete("{paymentId:long}")]
    public async Task<IActionResult> DeletePayment(
        long paymentId)
    {
        var result = await _paymentService
            .DeletePaymentAsync(paymentId);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpPut("process/{paymentId:long}")]
    public async Task<IActionResult> ProcessPayment(
        long paymentId)
    {
        var result = await _paymentService
            .ProcessPaymentAsync(paymentId);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpPut("cancel/{paymentId:long}")]
    public async Task<IActionResult> CancelPayment(
        long paymentId)
    {
        var result = await _paymentService
            .CancelPaymentAsync(paymentId);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpGet("exists/{paymentId:long}")]
    public async Task<IActionResult> Exists(
        long paymentId)
    {
        var result = await _paymentService
            .ExistsAsync(paymentId);

        return Ok(result);
    }
}

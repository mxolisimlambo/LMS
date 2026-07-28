using LMS.Application.Interfaces.Payments;
using LMS.Shared.DTOs.Payments.PaymentMethod;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Payments;

[ApiController]
[Route("api/[controller]")]
public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodService _paymentMethodService;

    public PaymentMethodController(
        IPaymentMethodService paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPaymentMethods()
    {
        var result = await _paymentMethodService
            .GetAllPaymentMethodsAsync();

        return Ok(result);
    }

    [HttpGet("{paymentMethodId:long}")]
    public async Task<IActionResult> GetPaymentMethodById(
        long paymentMethodId)
    {
        var result = await _paymentMethodService
            .GetPaymentMethodByIdAsync(paymentMethodId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaymentMethod(
        CreatePaymentMethodDto dto)
    {
        var result = await _paymentMethodService
            .CreatePaymentMethodAsync(dto);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePaymentMethod(
        UpdatePaymentMethodDto dto)
    {
        var result = await _paymentMethodService
            .UpdatePaymentMethodAsync(dto);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpDelete("{paymentMethodId:long}")]
    public async Task<IActionResult> DeletePaymentMethod(
        long paymentMethodId)
    {
        var result = await _paymentMethodService
            .DeletePaymentMethodAsync(paymentMethodId);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpPut("activate/{paymentMethodId:long}")]
    public async Task<IActionResult> ActivatePaymentMethod(
        long paymentMethodId)
    {
        var result = await _paymentMethodService
            .ActivatePaymentMethodAsync(paymentMethodId);

        if (!result)
            return BadRequest();

        return Ok(result);
    }

    [HttpPut("deactivate/{paymentMethodId:long}")]
    public async Task<IActionResult> DeactivatePaymentMethod(
        long paymentMethodId)
    {
        var result = await _paymentMethodService
            .DeactivatePaymentMethodAsync(paymentMethodId);

        if (!result)
            return BadRequest();

        return Ok(result);
    }
}

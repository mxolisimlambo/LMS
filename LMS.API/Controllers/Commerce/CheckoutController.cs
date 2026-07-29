using LMS.Application.Interfaces.Commerce.Checkout;
using LMS.Shared.DTOs.Commerce.Checkout;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Commerce;

[ApiController]
[Route("api/[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly ICheckoutService _checkoutService;

    public CheckoutController(
        ICheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    // ======================================================
    // CHECKOUT
    // ======================================================

    [HttpPost]
    public async Task<IActionResult> Checkout(
        [FromBody] CheckoutDto dto)
    {
        var result = await _checkoutService
            .CheckoutAsync(dto);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
using LMS.Application.Interfaces.Commerce;
using LMS.Shared.DTOs.Commerce.ShoppingCart.Cart;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Commerce;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(
        IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllShoppingCarts()
    {
        var result = await _shoppingCartService
            .GetAllShoppingCartsAsync();

        return Ok(result);
    }

    [HttpGet("{shoppingCartId:long}")]
    public async Task<IActionResult> GetShoppingCartById(
        long shoppingCartId)
    {
        var result = await _shoppingCartService
            .GetShoppingCartByIdAsync(
                shoppingCartId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("student/{studentProfileId:long}")]
    public async Task<IActionResult> GetShoppingCartByStudent(
        long studentProfileId)
    {
        var result = await _shoppingCartService
            .GetShoppingCartByStudentAsync(
                studentProfileId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShoppingCart(
        [FromBody] CreateShoppingCartDto dto)
    {
        var result = await _shoppingCartService
            .CreateShoppingCartAsync(dto);

        if (!result)
        {
            return BadRequest(
                "The shopping cart could not be created. " +
                "The student may not exist or may already have an active cart.");
        }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateShoppingCart(
        [FromBody] UpdateShoppingCartDto dto)
    {
        var result = await _shoppingCartService
            .UpdateShoppingCartAsync(dto);

        if (!result)
        {
            return BadRequest(
                "The shopping cart could not be updated.");
        }

        return Ok(result);
    }

    [HttpDelete("{shoppingCartId:long}")]
    public async Task<IActionResult> DeleteShoppingCart(
        long shoppingCartId)
    {
        var result = await _shoppingCartService
            .DeleteShoppingCartAsync(
                shoppingCartId);

        if (!result)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("clear/{shoppingCartId:long}")]
    public async Task<IActionResult> ClearShoppingCart(
        long shoppingCartId)
    {
        var result = await _shoppingCartService
            .ClearShoppingCartAsync(
                shoppingCartId);

        if (!result)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("restore/{shoppingCartId:long}")]
    public async Task<IActionResult> RestoreShoppingCart(
        long shoppingCartId)
    {
        var result = await _shoppingCartService
            .RestoreShoppingCartAsync(
                shoppingCartId);

        if (!result)
        {
            return BadRequest(
                "The shopping cart could not be restored. " +
                "The student may already have another active cart.");
        }

        return Ok(result);
    }

    [HttpGet("exists/{shoppingCartId:long}")]
    public async Task<IActionResult> Exists(
        long shoppingCartId)
    {
        var result = await _shoppingCartService
            .ExistsAsync(shoppingCartId);

        return Ok(result);
    }
}
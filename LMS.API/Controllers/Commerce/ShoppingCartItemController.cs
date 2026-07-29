using LMS.Application.Interfaces.Commerce;
using LMS.Shared.DTOs.Commerce.ShoppingCart.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Commerce;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartItemController : ControllerBase
{
    private readonly IShoppingCartItemService _shoppingCartItemService;

    public ShoppingCartItemController(
        IShoppingCartItemService shoppingCartItemService)
    {
        _shoppingCartItemService = shoppingCartItemService;
    }

    // ======================================================
    // GET ALL ITEMS BY SHOPPING CART
    // ======================================================

    [HttpGet("cart/{shoppingCartId:long}")]
    public async Task<IActionResult> GetShoppingCartItemsByCart(
        long shoppingCartId)
    {
        var result = await _shoppingCartItemService
            .GetShoppingCartItemsByCartAsync(
                shoppingCartId);

        return Ok(result);
    }

    // ======================================================
    // GET ITEM SUMMARIES BY SHOPPING CART
    // ======================================================

    [HttpGet("cart/{shoppingCartId:long}/summary")]
    public async Task<IActionResult>
        GetShoppingCartItemSummariesByCart(
            long shoppingCartId)
    {
        var result = await _shoppingCartItemService
            .GetShoppingCartItemSummariesByCartAsync(
                shoppingCartId);

        return Ok(result);
    }

    // ======================================================
    // GET SHOPPING CART ITEM BY ID
    // ======================================================

    [HttpGet("{shoppingCartItemId:long}")]
    public async Task<IActionResult>
        GetShoppingCartItemById(
            long shoppingCartItemId)
    {
        var result = await _shoppingCartItemService
            .GetShoppingCartItemByIdAsync(
                shoppingCartItemId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // ======================================================
    // CREATE SHOPPING CART ITEM
    // ======================================================

    
    // ======================================================
    // UPDATE SHOPPING CART ITEM
    // ======================================================

    [HttpPut]
    public async Task<IActionResult>
        UpdateShoppingCartItem(
            [FromBody] UpdateShoppingCartItemDto dto)
    {
        var result = await _shoppingCartItemService
            .UpdateShoppingCartItemAsync(dto);

        if (!result)
        {
            return BadRequest(
                "The shopping cart item could not be updated.");
        }

        return Ok(result);
    }

    // ======================================================
    // SOFT DELETE SHOPPING CART ITEM
    // ======================================================

    [HttpDelete("{shoppingCartItemId:long}")]
    public async Task<IActionResult>
        DeleteShoppingCartItem(
            long shoppingCartItemId)
    {
        var result = await _shoppingCartItemService
            .DeleteShoppingCartItemAsync(
                shoppingCartItemId);

        if (!result)
            return NotFound();

        return Ok(result);
    }

    // ======================================================
    // RESTORE SHOPPING CART ITEM
    // ======================================================

    [HttpPut("restore/{shoppingCartItemId:long}")]
    public async Task<IActionResult>
        RestoreShoppingCartItem(
            long shoppingCartItemId)
    {
        var result = await _shoppingCartItemService
            .RestoreShoppingCartItemAsync(
                shoppingCartItemId);

        if (!result)
        {
            return BadRequest(
                "The shopping cart item could not be restored. " +
                "The shopping cart may be inactive, or the course may " +
                "already exist in the active shopping cart.");
        }

        return Ok(result);
    }

    // ======================================================
    // CHECK WHETHER SHOPPING CART ITEM EXISTS
    // ======================================================

    [HttpGet("exists/{shoppingCartItemId:long}")]
    public async Task<IActionResult>
        Exists(
            long shoppingCartItemId)
    {
        var result = await _shoppingCartItemService
            .ExistsAsync(
                shoppingCartItemId);

        return Ok(result);
    }
}
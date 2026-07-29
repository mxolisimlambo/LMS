using LMS.Application.Interfaces.Commerce;
using LMS.Shared.DTOs.Commerce.Orders.OrderItem;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Commerce;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController : ControllerBase
{
private readonly IOrderItemService _orderItemService;

public OrderItemController(
    IOrderItemService orderItemService)
{
    _orderItemService = orderItemService;
}

// ======================================================
// GET ORDER ITEM BY ID
// ======================================================

[HttpGet("{orderItemId:long}")]
public async Task<IActionResult> GetOrderItemById(
    long orderItemId)
{
    var result = await _orderItemService
        .GetOrderItemByIdAsync(orderItemId);

    if (result == null)
    {
        return NotFound(
            $"Order item with ID {orderItemId} was not found.");
    }

    return Ok(result);
}

// ======================================================
// GET ALL ORDER ITEMS BY ORDER
// ======================================================

[HttpGet("order/{orderId:long}")]
public async Task<IActionResult> GetOrderItemsByOrder(
    long orderId)
{
    var result = await _orderItemService
        .GetOrderItemsByOrderAsync(orderId);

    return Ok(result);
}

// ======================================================
// UPDATE ORDER ITEM
// ======================================================

[HttpPut]
public async Task<IActionResult> UpdateOrderItem(
    [FromBody] UpdateOrderItemDto dto)
{
    var result = await _orderItemService
        .UpdateOrderItemAsync(dto);

    if (!result)
    {
        return BadRequest(
            "The order item could not be updated. " +
            "The order item may not exist, or the order may " +
            "already be completed or cancelled.");
    }

    return Ok(new
    {
        Message =
            "The order item was processed successfully.",
        Success = true
    });
}

// ======================================================
// SOFT DELETE ORDER ITEM
// ======================================================

[HttpDelete("{orderItemId:long}")]
public async Task<IActionResult> DeleteOrderItem(
    long orderItemId)
{
    var result = await _orderItemService
        .DeleteOrderItemAsync(orderItemId);

    if (!result)
    {
        return BadRequest(
            "The order item could not be deleted. " +
            "The order item may not exist, or the order may " +
            "already be completed or cancelled.");
    }

    return Ok(new
    {
        Message =
            "The order item was deleted successfully.",
        Success = true
    });
}

// ======================================================
// CHECK WHETHER ORDER ITEM EXISTS
// ======================================================

[HttpGet("exists/{orderItemId:long}")]
public async Task<IActionResult> Exists(
    long orderItemId)
{
    var result = await _orderItemService
        .ExistsAsync(orderItemId);

    return Ok(new
    {
        OrderItemId = orderItemId,
        Exists = result
    });
}

}

using LMS.Application.Interfaces.Commerce;
using LMS.Shared.DTOs.Commerce.Orders.Order;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Commerce;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
private readonly IOrderService _orderService;

public OrderController(
    IOrderService orderService)
{
    _orderService = orderService;
}

// ======================================================
// GET ALL ORDERS
// ======================================================

[HttpGet]
public async Task<IActionResult> GetAllOrders()
{
    var result = await _orderService
        .GetAllOrdersAsync();

    return Ok(result);
}

// ======================================================
// GET ORDER BY ID
// ======================================================

[HttpGet("{orderId:long}")]
public async Task<IActionResult> GetOrderById(
    long orderId)
{
    var result = await _orderService
        .GetOrderByIdAsync(orderId);

    if (result == null)
    {
        return NotFound(
            $"Order with ID {orderId} was not found.");
    }

    return Ok(result);
}

// ======================================================
// GET ORDER BY ORDER NUMBER
// ======================================================

[HttpGet("number/{orderNumber}")]
public async Task<IActionResult> GetOrderByNumber(
    string orderNumber)
{
    var result = await _orderService
        .GetOrderByNumberAsync(orderNumber);

    if (result == null)
    {
        return NotFound(
            $"Order with number '{orderNumber}' was not found.");
    }

    return Ok(result);
}

// ======================================================
// GET ORDERS BY STUDENT
// ======================================================

[HttpGet("student/{studentProfileId:long}")]
public async Task<IActionResult> GetOrdersByStudent(
    long studentProfileId)
{
    var result = await _orderService
        .GetOrdersByStudentAsync(
            studentProfileId);

    return Ok(result);
}

// ======================================================
// GET ORDERS BY STATUS
// ======================================================

[HttpGet("status/{orderStatus}")]
public async Task<IActionResult> GetOrdersByStatus(
    string orderStatus)
{
    var result = await _orderService
        .GetOrdersByStatusAsync(
            orderStatus);

    return Ok(result);
}

// ======================================================
// CREATE ORDER FROM SHOPPING CART
// ======================================================

[HttpPost]
public async Task<IActionResult> CreateOrder(
    [FromBody] CreateOrderDto dto)
{
    var result = await _orderService
        .CreateOrderAsync(dto);

    if (!result)
    {
        return BadRequest(
            "The order could not be created. " +
            "The student may not exist, the shopping cart may " +
            "not exist, the shopping cart may be empty, or one " +
            "or more courses may no longer be available.");
    }

    return Ok(new
    {
        Message =
            "The order was created successfully.",
        Success = true
    });
}

// ======================================================
// UPDATE ORDER STATUS
// ======================================================

[HttpPut]
public async Task<IActionResult> UpdateOrder(
    [FromBody] UpdateOrderDto dto)
{
    var result = await _orderService
        .UpdateOrderAsync(dto);

    if (!result)
    {
        return BadRequest(
            "The order could not be updated.");
    }

    return Ok(new
    {
        Message =
            "The order was updated successfully.",
        Success = true
    });
}

// ======================================================
// CANCEL ORDER
// ======================================================

[HttpPut("cancel/{orderId:long}")]
public async Task<IActionResult> CancelOrder(
    long orderId)
{
    var result = await _orderService
        .CancelOrderAsync(orderId);

    if (!result)
    {
        return BadRequest(
            "The order could not be cancelled. " +
            "The order may not exist, may already be cancelled, " +
            "or may already be completed.");
    }

    return Ok(new
    {
        Message =
            "The order was cancelled successfully.",
        Success = true
    });
}

// ======================================================
// COMPLETE ORDER
// ======================================================

[HttpPut("complete/{orderId:long}")]
public async Task<IActionResult> CompleteOrder(
    long orderId)
{
    var result = await _orderService
        .CompleteOrderAsync(orderId);

    if (!result)
    {
        return BadRequest(
            "The order could not be completed. " +
            "The order may not exist or may already be cancelled.");
    }

    return Ok(new
    {
        Message =
            "The order was completed successfully.",
        Success = true
    });
}

// ======================================================
// SOFT DELETE ORDER
// ======================================================

[HttpDelete("{orderId:long}")]
public async Task<IActionResult> DeleteOrder(
    long orderId)
{
    var result = await _orderService
        .DeleteOrderAsync(orderId);

    if (!result)
    {
        return NotFound(
            $"Order with ID {orderId} was not found.");
    }

    return Ok(new
    {
        Message =
            "The order was deleted successfully.",
        Success = true
    });
}

// ======================================================
// CHECK WHETHER ORDER EXISTS
// ======================================================

[HttpGet("exists/{orderId:long}")]
public async Task<IActionResult> Exists(
    long orderId)
{
    var result = await _orderService
        .ExistsAsync(orderId);

    return Ok(new
    {
        OrderId = orderId,
        Exists = result
    });
}

}

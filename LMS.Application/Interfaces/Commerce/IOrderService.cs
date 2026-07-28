using LMS.Shared.DTOs.Commerce.Orders.Order;

namespace LMS.Application.Interfaces.Commerce;

public interface IOrderService
{
    Task<bool> CreateOrderAsync(
        CreateOrderDto dto);

    Task<bool> UpdateOrderAsync(
        UpdateOrderDto dto);

    Task<bool> DeleteOrderAsync(
        long orderId);

    Task<OrderDto?> GetOrderByIdAsync(
        long orderId);

    Task<OrderDto?> GetOrderByNumberAsync(
        string orderNumber);

    Task<IEnumerable<OrderSummaryDto>>
        GetOrdersByStudentAsync(
            long studentProfileId);

    Task<IEnumerable<OrderSummaryDto>>
        GetAllOrdersAsync();

    Task<IEnumerable<OrderSummaryDto>>
        GetOrdersByStatusAsync(
            string orderStatus);

    Task<bool> CancelOrderAsync(
        long orderId);

    Task<bool> CompleteOrderAsync(
        long orderId);

    Task<bool> ExistsAsync(
        long orderId);
}
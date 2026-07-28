using LMS.Shared.DTOs.Commerce.Orders.OrderItem;

namespace LMS.Application.Interfaces.Commerce;

public interface IOrderItemService
{
    Task<bool> CreateOrderItemAsync(
        CreateOrderItemDto dto);

    Task<bool> UpdateOrderItemAsync(
        UpdateOrderItemDto dto);

    Task<bool> DeleteOrderItemAsync(
        long orderItemId);

    Task<OrderItemDto?> GetOrderItemByIdAsync(
        long orderItemId);

    Task<IEnumerable<OrderItemDto>>
        GetOrderItemsByOrderAsync(
            long orderId);

    Task<IEnumerable<OrderItemSummaryDto>>
        GetOrderItemSummariesByOrderAsync(
            long orderId);

    Task<bool> ExistsAsync(
        long orderItemId);
}
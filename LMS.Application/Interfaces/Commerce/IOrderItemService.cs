using LMS.Domain.Entities.Commerce.Orders;
using LMS.Domain.Entities.Commerce.ShoppingCard;
using LMS.Shared.DTOs.Commerce.Orders.OrderItem;

namespace LMS.Application.Interfaces.Commerce;

public interface IOrderItemService
{
    // ======================================================
    // CREATE ORDER ITEMS FROM SHOPPING CART
    // ======================================================

    Task CreateOrderItemsAsync(
        long orderId,
        IEnumerable<ShoppingCartItem> shoppingCartItems);

    // ======================================================
    // UPDATE ORDER ITEM
    // ======================================================

    Task<bool> UpdateOrderItemAsync(
        UpdateOrderItemDto dto);

    // ======================================================
    // DELETE ORDER ITEM
    // ======================================================

    Task<bool> DeleteOrderItemAsync(
        long orderItemId);

    // ======================================================
    // GET ORDER ITEM
    // ======================================================

    Task<OrderItemDto?> GetOrderItemByIdAsync(
        long orderItemId);

    // ======================================================
    // GET ORDER ITEMS
    // ======================================================

    Task<IEnumerable<OrderItemDto>>
        GetOrderItemsByOrderAsync(
            long orderId);

   // Task<IEnumerable<OrderItemSummaryDto>>
      //  GetAllOrderItemsAsync();

    // ======================================================
    // CHECK EXISTS
    // ======================================================

    Task<bool> ExistsAsync(
        long orderItemId);
}
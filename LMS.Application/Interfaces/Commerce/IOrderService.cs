using LMS.Shared.DTOs.Commerce.Orders.Order;
using LMS.Domain.Entities.Commerce.Orders;
namespace LMS.Application.Interfaces.Commerce;

public interface IOrderService
{
   Task<Order> CreateOrderAsync(
    long studentProfileId,
    decimal subTotalAmount,
    decimal discountAmount,
    decimal totalAmount,
    string currency);

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
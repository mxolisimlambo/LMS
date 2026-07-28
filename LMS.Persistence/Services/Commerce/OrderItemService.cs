using LMS.Application.Interfaces.Commerce;
using LMS.Domain.Entities.Commerce.Orders;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Commerce.Orders.OrderItem;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Commerce;

public class OrderItemService : IOrderItemService
{
    private readonly ApplicationDbContext _context;

    public OrderItemService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    // ======================================================
    // CREATE ORDER ITEM
    // ======================================================

    public async Task<bool> CreateOrderItemAsync(
        CreateOrderItemDto dto)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(x =>
                x.OrderId == dto.OrderId &&
                !x.IsDeleted);

        if (order == null)
            return false;

        // Order items must not be added to completed
        // or cancelled orders.
        if (order.OrderStatus == "Completed" ||
            order.OrderStatus == "Cancelled")
        {
            return false;
        }

        var course = await _context.Courses
            .Include(x => x.CoursePrice)
            .FirstOrDefaultAsync(x =>
                x.CourseId == dto.CourseId &&
                !x.IsDeleted);

        if (course == null)
            return false;

        if (!course.IsPublished)
            return false;

        var duplicateExists = await _context.OrderItems
            .AnyAsync(x =>
                x.OrderId == dto.OrderId &&
                x.CourseId == dto.CourseId &&
                !x.IsDeleted);

        if (duplicateExists)
            return false;

        var unitPrice =
            course.CoursePrice?.Price ?? 0m;

        var discountAmount = 0m;

        var totalPrice =
            unitPrice - discountAmount;

        if (totalPrice < 0)
            totalPrice = 0;

        var orderItem = new OrderItem
        {
            OrderId = dto.OrderId,

            CourseId = dto.CourseId,

            CourseTitle = course.Title,

            UnitPrice = unitPrice,

            DiscountAmount = discountAmount,

            TotalPrice = totalPrice,

            CreatedDate = DateTime.UtcNow,

            IsDeleted = false
        };

        _context.OrderItems.Add(
            orderItem);

        await RecalculateOrderTotalsAsync(
            dto.OrderId);

        return true;
    }

    // ======================================================
    // UPDATE ORDER ITEM
    // ======================================================

    public async Task<bool> UpdateOrderItemAsync(
        UpdateOrderItemDto dto)
    {
        var orderItem = await _context.OrderItems
            .Include(x => x.Order)
            .FirstOrDefaultAsync(x =>
                x.OrderItemId == dto.OrderItemId &&
                !x.IsDeleted);

        if (orderItem == null)
            return false;

        if (orderItem.Order == null)
            return false;

        // Historical purchase information must not
        // be changed after the order is completed.
        if (orderItem.Order.OrderStatus == "Completed" ||
            orderItem.Order.OrderStatus == "Cancelled")
        {
            return false;
        }

        // This method currently exists because the
        // interface contains UpdateOrderItemAsync.
        // Order item prices and course details are
        // historical financial information and must
        // not be changed.

        return true;
    }

    // ======================================================
    // SOFT DELETE ORDER ITEM
    // ======================================================

    public async Task<bool> DeleteOrderItemAsync(
        long orderItemId)
    {
        var orderItem = await _context.OrderItems
            .Include(x => x.Order)
            .FirstOrDefaultAsync(x =>
                x.OrderItemId == orderItemId &&
                !x.IsDeleted);

        if (orderItem == null)
            return false;

        if (orderItem.Order == null)
            return false;

        // Do not allow items to be removed from
        // completed or cancelled orders.
        if (orderItem.Order.OrderStatus == "Completed" ||
            orderItem.Order.OrderStatus == "Cancelled")
        {
            return false;
        }

        orderItem.IsDeleted = true;

        await RecalculateOrderTotalsAsync(
            orderItem.OrderId);

        return true;
    }

    // ======================================================
    // GET ORDER ITEM BY ID
    // ======================================================

    public async Task<OrderItemDto?>
        GetOrderItemByIdAsync(
            long orderItemId)
    {
        return await _context.OrderItems
            .Where(x =>
                x.OrderItemId == orderItemId &&
                !x.IsDeleted)
            .Select(x => new OrderItemDto
            {
                OrderItemId =
                    x.OrderItemId,

                OrderId =
                    x.OrderId,

                CourseId =
                    x.CourseId,

                CourseTitle =
                    x.CourseTitle,

                UnitPrice =
                    x.UnitPrice,

                DiscountAmount =
                    x.DiscountAmount,

                TotalPrice =
                    x.TotalPrice,

                CreatedDate =
                    x.CreatedDate,

                IsDeleted =
                    x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    // ======================================================
    // GET ALL ORDER ITEMS BY ORDER
    // ======================================================

    public async Task<IEnumerable<
        OrderItemDto>>
        GetOrderItemsByOrderAsync(
            long orderId)
    {
        return await _context.OrderItems
            .Where(x =>
                x.OrderId == orderId &&
                !x.IsDeleted)
            .OrderBy(x =>
                x.CreatedDate)
            .Select(x => new OrderItemDto
            {
                OrderItemId =
                    x.OrderItemId,

                OrderId =
                    x.OrderId,

                CourseId =
                    x.CourseId,

                CourseTitle =
                    x.CourseTitle,

                UnitPrice =
                    x.UnitPrice,

                DiscountAmount =
                    x.DiscountAmount,

                TotalPrice =
                    x.TotalPrice,

                CreatedDate =
                    x.CreatedDate,

                IsDeleted =
                    x.IsDeleted
            })
            .ToListAsync();
    }

    // ======================================================
    // GET ORDER ITEM SUMMARIES BY ORDER
    // ======================================================

    public async Task<IEnumerable<
        OrderItemSummaryDto>>
        GetOrderItemSummariesByOrderAsync(
            long orderId)
    {
        return await _context.OrderItems
            .Where(x =>
                x.OrderId == orderId &&
                !x.IsDeleted)
            .OrderBy(x =>
                x.CreatedDate)
            .Select(x =>
                new OrderItemSummaryDto
                {
                    OrderItemId =
                        x.OrderItemId,

                    CourseId =
                        x.CourseId,

                    CourseTitle =
                        x.CourseTitle,

                    TotalPrice =
                        x.TotalPrice
                })
            .ToListAsync();
    }

    // ======================================================
    // CHECK ORDER ITEM EXISTS
    // ======================================================

    public async Task<bool> ExistsAsync(
        long orderItemId)
    {
        return await _context.OrderItems
            .AnyAsync(x =>
                x.OrderItemId == orderItemId &&
                !x.IsDeleted);
    }

    // ======================================================
    // RECALCULATE ORDER TOTALS
    // ======================================================

    private async Task RecalculateOrderTotalsAsync(
        long orderId)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(x =>
                x.OrderId == orderId &&
                !x.IsDeleted);

        if (order == null)
            return;

        var activeOrderItems =
            await _context.OrderItems
                .Where(x =>
                    x.OrderId == orderId &&
                    !x.IsDeleted)
                .ToListAsync();

        order.SubTotalAmount =
            activeOrderItems.Sum(
                x => x.UnitPrice);

        order.DiscountAmount =
            activeOrderItems.Sum(
                x => x.DiscountAmount);

        order.TotalAmount =
            activeOrderItems.Sum(
                x => x.TotalPrice);

        order.UpdatedDate =
            DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }
}
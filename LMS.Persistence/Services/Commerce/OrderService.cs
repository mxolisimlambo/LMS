using LMS.Application.Interfaces.Commerce;
using LMS.Domain.Entities.Commerce.Orders;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Commerce.Orders.Order;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Commerce;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    // ======================================================
    // CREATE ORDER FROM SHOPPING CART
    // ======================================================

    public async Task<bool> CreateOrderAsync(
        CreateOrderDto dto)
    {
        var studentExists = await _context.StudentProfiles
            .AnyAsync(x =>
                x.StudentProfileId == dto.StudentProfileId &&
                !x.IsDeleted);

        if (!studentExists)
            return false;

        var shoppingCart = await _context.ShoppingCarts
            .FirstOrDefaultAsync(x =>
                x.StudentProfileId == dto.StudentProfileId &&
                !x.IsDeleted);

        if (shoppingCart == null)
            return false;

        var cartItems = await _context.ShoppingCartItems
            .Include(x => x.Course)
            .Where(x =>
                x.ShoppingCartId == shoppingCart.ShoppingCartId &&
                !x.IsDeleted)
            .ToListAsync();

        if (!cartItems.Any())
            return false;

        foreach (var cartItem in cartItems)
        {
            if (cartItem.Course == null)
                return false;

            if (cartItem.Course.IsDeleted)
                return false;

            if (!cartItem.Course.IsPublished)
                return false;
        }

        var subTotalAmount = cartItems
            .Sum(x => x.UnitPrice);

        var discountAmount = cartItems
            .Sum(x => x.DiscountAmount);

        var totalAmount = cartItems
            .Sum(x => x.TotalPrice);

        var order = new Order
        {
            StudentProfileId = dto.StudentProfileId,

            OrderNumber = GenerateOrderNumber(),

            SubTotalAmount = subTotalAmount,

            DiscountAmount = discountAmount,

            TotalAmount = totalAmount,

            Currency = string.IsNullOrWhiteSpace(
                dto.Currency)
                    ? "ZAR"
                    : dto.Currency.ToUpper(),

            OrderStatus = "Pending",

            OrderDate = DateTime.UtcNow,

            UpdatedDate = null,

            IsDeleted = false
        };

        foreach (var cartItem in cartItems)
        {
            var orderItem = new OrderItem
            {
                CourseId = cartItem.CourseId,

                CourseTitle =
                    cartItem.Course?.Title
                    ?? string.Empty,

                UnitPrice =
                    cartItem.UnitPrice,

                DiscountAmount =
                    cartItem.DiscountAmount,

                TotalPrice =
                    cartItem.TotalPrice,

                CreatedDate =
                    DateTime.UtcNow,

                IsDeleted = false
            };

            order.OrderItems.Add(
                orderItem);
        }

        _context.Orders.Add(order);

        foreach (var cartItem in cartItems)
        {
            cartItem.IsDeleted = true;
        }

        shoppingCart.TotalItems = 0;

        shoppingCart.TotalAmount = 0;

        shoppingCart.UpdatedDate =
            DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    // ======================================================
    // UPDATE ORDER STATUS
    // ======================================================

    public async Task<bool> UpdateOrderAsync(
        UpdateOrderDto dto)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(x =>
                x.OrderId == dto.OrderId &&
                !x.IsDeleted);

        if (order == null)
            return false;

        if (string.IsNullOrWhiteSpace(
            dto.OrderStatus))
            return false;

        order.OrderStatus =
            dto.OrderStatus.Trim();

        order.UpdatedDate =
            DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    // ======================================================
    // SOFT DELETE ORDER
    // ======================================================

    public async Task<bool> DeleteOrderAsync(
        long orderId)
    {
        var order = await _context.Orders
            .Include(x => x.OrderItems)
            .FirstOrDefaultAsync(x =>
                x.OrderId == orderId &&
                !x.IsDeleted);

        if (order == null)
            return false;

        order.IsDeleted = true;

        order.UpdatedDate =
            DateTime.UtcNow;

        foreach (var orderItem
            in order.OrderItems)
        {
            orderItem.IsDeleted = true;
        }

        await _context.SaveChangesAsync();

        return true;
    }

    // ======================================================
    // GET ORDER BY ID
    // ======================================================

    public async Task<OrderDto?>
        GetOrderByIdAsync(
            long orderId)
    {
        return await _context.Orders
            .Where(x =>
                x.OrderId == orderId &&
                !x.IsDeleted)
            .Select(x => new OrderDto
            {
                OrderId =
                    x.OrderId,

                StudentProfileId =
                    x.StudentProfileId,

                OrderNumber =
                    x.OrderNumber,

                SubTotalAmount =
                    x.SubTotalAmount,

                DiscountAmount =
                    x.DiscountAmount,

                TotalAmount =
                    x.TotalAmount,

                Currency =
                    x.Currency,

                OrderStatus =
                    x.OrderStatus,

                OrderDate =
                    x.OrderDate,

                UpdatedDate =
                    x.UpdatedDate,

                IsDeleted =
                    x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    // ======================================================
    // GET ORDER BY NUMBER
    // ======================================================

    public async Task<OrderDto?>
        GetOrderByNumberAsync(
            string orderNumber)
    {
        if (string.IsNullOrWhiteSpace(
            orderNumber))
            return null;

        var normalizedOrderNumber =
            orderNumber.Trim();

        return await _context.Orders
            .Where(x =>
                x.OrderNumber ==
                normalizedOrderNumber &&
                !x.IsDeleted)
            .Select(x => new OrderDto
            {
                OrderId =
                    x.OrderId,

                StudentProfileId =
                    x.StudentProfileId,

                OrderNumber =
                    x.OrderNumber,

                SubTotalAmount =
                    x.SubTotalAmount,

                DiscountAmount =
                    x.DiscountAmount,

                TotalAmount =
                    x.TotalAmount,

                Currency =
                    x.Currency,

                OrderStatus =
                    x.OrderStatus,

                OrderDate =
                    x.OrderDate,

                UpdatedDate =
                    x.UpdatedDate,

                IsDeleted =
                    x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    // ======================================================
    // GET ORDERS BY STUDENT
    // ======================================================

    public async Task<IEnumerable<
        OrderSummaryDto>>
        GetOrdersByStudentAsync(
            long studentProfileId)
    {
        return await _context.Orders
            .Where(x =>
                x.StudentProfileId ==
                studentProfileId &&
                !x.IsDeleted)
            .OrderByDescending(
                x => x.OrderDate)
            .Select(x =>
                new OrderSummaryDto
                {
                    OrderId =
                        x.OrderId,

                    OrderNumber =
                        x.OrderNumber,

                    TotalAmount =
                        x.TotalAmount,

                    Currency =
                        x.Currency,

                    OrderStatus =
                        x.OrderStatus,

                    OrderDate =
                        x.OrderDate,

                    TotalItems =
                        x.OrderItems
                            .Count(item =>
                                !item.IsDeleted)
                })
            .ToListAsync();
    }

    // ======================================================
    // GET ALL ORDERS
    // ======================================================

    public async Task<IEnumerable<
        OrderSummaryDto>>
        GetAllOrdersAsync()
    {
        return await _context.Orders
            .Where(x =>
                !x.IsDeleted)
            .OrderByDescending(
                x => x.OrderDate)
            .Select(x =>
                new OrderSummaryDto
                {
                    OrderId =
                        x.OrderId,

                    OrderNumber =
                        x.OrderNumber,

                    TotalAmount =
                        x.TotalAmount,

                    Currency =
                        x.Currency,

                    OrderStatus =
                        x.OrderStatus,

                    OrderDate =
                        x.OrderDate,

                    TotalItems =
                        x.OrderItems
                            .Count(item =>
                                !item.IsDeleted)
                })
            .ToListAsync();
    }

    // ======================================================
    // GET ORDERS BY STATUS
    // ======================================================

    public async Task<IEnumerable<
        OrderSummaryDto>>
        GetOrdersByStatusAsync(
            string orderStatus)
    {
        if (string.IsNullOrWhiteSpace(
            orderStatus))
        {
            return new List<
                OrderSummaryDto>();
        }

        var normalizedStatus =
            orderStatus.Trim();

        return await _context.Orders
            .Where(x =>
                x.OrderStatus ==
                normalizedStatus &&
                !x.IsDeleted)
            .OrderByDescending(
                x => x.OrderDate)
            .Select(x =>
                new OrderSummaryDto
                {
                    OrderId =
                        x.OrderId,

                    OrderNumber =
                        x.OrderNumber,

                    TotalAmount =
                        x.TotalAmount,

                    Currency =
                        x.Currency,

                    OrderStatus =
                        x.OrderStatus,

                    OrderDate =
                        x.OrderDate,

                    TotalItems =
                        x.OrderItems
                            .Count(item =>
                                !item.IsDeleted)
                })
            .ToListAsync();
    }

    // ======================================================
    // CANCEL ORDER
    // ======================================================

    public async Task<bool>
        CancelOrderAsync(
            long orderId)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(x =>
                x.OrderId == orderId &&
                !x.IsDeleted);

        if (order == null)
            return false;

        if (order.OrderStatus ==
            "Completed")
            return false;

        if (order.OrderStatus ==
            "Cancelled")
            return false;

        order.OrderStatus =
            "Cancelled";

        order.UpdatedDate =
            DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    // ======================================================
    // COMPLETE ORDER
    // ======================================================

    public async Task<bool>
        CompleteOrderAsync(
            long orderId)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(x =>
                x.OrderId == orderId &&
                !x.IsDeleted);

        if (order == null)
            return false;

        if (order.OrderStatus ==
            "Cancelled")
            return false;

        order.OrderStatus =
            "Completed";

        order.UpdatedDate =
            DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    // ======================================================
    // CHECK ORDER EXISTS
    // ======================================================

    public async Task<bool>
        ExistsAsync(
            long orderId)
    {
        return await _context.Orders
            .AnyAsync(x =>
                x.OrderId == orderId &&
                !x.IsDeleted);
    }

    // ======================================================
    // GENERATE ORDER NUMBER
    // ======================================================

    private static string
        GenerateOrderNumber()
    {
        return
            $"ORD-{DateTime.UtcNow:yyyyMMddHHmmssfff}-" +
            $"{Guid.NewGuid().ToString("N")[..6].ToUpper()}";
    }
}
using LMS.Application.Interfaces.Commerce;
using LMS.Application.Interfaces.Commerce.Checkout;
using LMS.Application.Interfaces.Payments;
using LMS.Application.Interfaces.Enrollments;
using LMS.Shared.DTOs.Commerce.Checkout;

namespace LMS.Persistence.Services.Commerce.Checkout;

public class CheckoutService : ICheckoutService
{
private readonly IShoppingCartService _shoppingCartService;
private readonly IEnrollmentService _enrollmentService;
private readonly IShoppingCartItemService _shoppingCartItemService;
private readonly IOrderService _orderService;
private readonly IOrderItemService _orderItemService;
private readonly IPaymentService _paymentService;

public CheckoutService(
    IShoppingCartService shoppingCartService,
    IEnrollmentService enrollmentService,
    IShoppingCartItemService shoppingCartItemService,
    IOrderService orderService,
    IOrderItemService orderItemService,
    IPaymentService paymentService)
{
    _shoppingCartService = shoppingCartService;
    _enrollmentService = enrollmentService;
    _shoppingCartItemService = shoppingCartItemService;
    _orderService = orderService;
    _orderItemService = orderItemService;
    _paymentService = paymentService;
}

// ======================================================
// CHECKOUT SHOPPING CART
// ======================================================

public async Task<CheckoutResultDto> CheckoutAsync(
    CheckoutDto dto)
    {
    
    // ======================================================
// VALIDATE SHOPPING CART
// ======================================================

var validShoppingCart =
    await _shoppingCartService
        .ValidateShoppingCartAsync(
            dto.StudentProfileId);

if (!validShoppingCart)
{
    return new CheckoutResultDto
    {
        Success = false,
        Message = "Student or shopping cart not found."
    };
}

// ======================================================
// VALIDATE PAYMENT METHOD
// ======================================================

var validPaymentMethod =
    await _paymentService
        .ValidatePaymentMethodAsync(
            dto.PaymentMethodId);

if (!validPaymentMethod)
{
    return new CheckoutResultDto
    {
        Success = false,
        Message = "Invalid payment method."
    };
}
    // ==================================================
    // GET ACTIVE SHOPPING CART
    // ==================================================

    var shoppingCart =
        await _shoppingCartService
            .GetActiveShoppingCartAsync(
                dto.StudentProfileId);

    if (shoppingCart == null)
    {
        return new CheckoutResultDto
        {
            Success = false,
            Message = "Shopping cart not found."
        };
    }

    // ==================================================
    // GET SHOPPING CART ITEMS
    // ==================================================

    var cartItems =
        await _shoppingCartItemService
            .GetCheckoutItemsAsync(
                shoppingCart.ShoppingCartId);

    if (!cartItems.Any())
    {
        return new CheckoutResultDto
        {
            Success = false,
            Message = "Shopping cart is empty."
        };
    }

    // ==================================================
    // CALCULATE TOTALS
    // ==================================================

    var subTotalAmount =
        cartItems.Sum(x => x.UnitPrice);

    var discountAmount =
        cartItems.Sum(x => x.DiscountAmount);

    var totalAmount =
        cartItems.Sum(x => x.TotalPrice);

    // ==================================================
    // CREATE ORDER
    // ==================================================

    var order =
        await _orderService
            .CreateOrderAsync(
                dto.StudentProfileId,
                subTotalAmount,
                discountAmount,
                totalAmount,
                dto.Currency);

    // ==================================================
    // CREATE ORDER ITEMS
    // ==================================================

    await _orderItemService
        .CreateOrderItemsAsync(
            order.OrderId,
            cartItems);

        // ==================================================
        // CREATE PAYMENT
        // ==================================================

        var payment =
            await _paymentService
                .CreatePaymentAsync(
                    order.OrderId,
                    dto.StudentProfileId,
                    dto.PaymentMethodId,
                    subTotalAmount,
                    discountAmount,
                    0m,
                    totalAmount,
                    dto.Currency);

            await _enrollmentService.CreateEnrollmentsAsync(
            dto.StudentProfileId,
           order.OrderId);

    // ==================================================
    // CLEAR SHOPPING CART ITEMS
    // ==================================================

    await _shoppingCartItemService
        .ClearShoppingCartItemsAsync(
            shoppingCart.ShoppingCartId);

    // ==================================================
    // CLOSE SHOPPING CART
    // ==================================================

    await _shoppingCartService
        .CloseShoppingCartAsync(
            shoppingCart.ShoppingCartId);

    // ==================================================
    // RETURN RESULT
    // ==================================================

    return new CheckoutResultDto
    {
        Success = true,

        Message =
            "Checkout completed successfully.",

        OrderId =
            order.OrderId,

        OrderNumber =
            order.OrderNumber,

        PaymentId =
            payment.PaymentId,

        PaymentStatus =
            payment.PaymentStatus,

        TotalAmount =
            payment.TotalAmount,

        Currency =
            payment.Currency
    };
}

}

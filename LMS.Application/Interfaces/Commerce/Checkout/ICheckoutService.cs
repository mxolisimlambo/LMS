using LMS.Shared.DTOs.Commerce.Checkout;

namespace LMS.Application.Interfaces.Commerce.Checkout;

public interface ICheckoutService
{
// ======================================================
// CREATE ORDER AND PAYMENT FROM SHOPPING CART
// ======================================================

Task<CheckoutResultDto> CheckoutAsync(
    CheckoutDto dto);

}

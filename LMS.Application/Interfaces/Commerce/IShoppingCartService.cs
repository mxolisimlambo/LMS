using LMS.Domain.Entities.Commerce.ShoppingCard;
using LMS.Shared.DTOs.Commerce.ShoppingCart.Cart;

namespace LMS.Application.Interfaces.Commerce;

public interface IShoppingCartService
{
    // ======================================================
    // CREATE SHOPPING CART
    // ======================================================

    Task<ShoppingCart> CreateShoppingCartAsync(
        long studentProfileId);

    // ======================================================
    // GET ACTIVE SHOPPING CART
    // ======================================================

    Task<ShoppingCart?> GetActiveShoppingCartAsync(
        long studentProfileId);

    // ======================================================
    // CLOSE SHOPPING CART AFTER CHECKOUT
    // ======================================================

    Task<bool> CloseShoppingCartAsync(
        long shoppingCartId);

    // ======================================================
    // UPDATE SHOPPING CART
    // ======================================================

    Task<bool> UpdateShoppingCartAsync(
        UpdateShoppingCartDto dto);

    // ======================================================
    // DELETE SHOPPING CART
    // ======================================================

    Task<bool> DeleteShoppingCartAsync(
        long shoppingCartId);

    // ======================================================
    // GET SHOPPING CART
    // ======================================================

    Task<ShoppingCartDto?> GetShoppingCartByIdAsync(
        long shoppingCartId);

    Task<ShoppingCartDto?> GetShoppingCartByStudentAsync(
        long studentProfileId);

    Task<IEnumerable<ShoppingCartSummaryDto>>
        GetAllShoppingCartsAsync();

    // ======================================================
    // CLEAR SHOPPING CART
    // ======================================================

    Task<bool> ClearShoppingCartAsync(
        long shoppingCartId);

    // ======================================================
    // RESTORE SHOPPING CART
    // ======================================================

    Task<bool> RestoreShoppingCartAsync(
        long shoppingCartId);

// ======================================================
// VALIDATE STUDENT SHOPPING CART
// ======================================================

Task<bool> ValidateShoppingCartAsync(
    long studentProfileId);

    // ======================================================
    // CHECK EXISTS
    // ======================================================

    Task<bool> ExistsAsync(
        long shoppingCartId);
}
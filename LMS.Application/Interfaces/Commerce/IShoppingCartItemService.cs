using LMS.Domain.Entities.Commerce.ShoppingCard;
using LMS.Shared.DTOs.Commerce.ShoppingCart.CartItem;

namespace LMS.Application.Interfaces.Commerce;

public interface IShoppingCartItemService
{
    // ======================================================
    // ADD COURSE TO SHOPPING CART
    // ======================================================

    Task<ShoppingCartItem?> AddCourseAsync(
        long shoppingCartId,
        long courseId);

    // ======================================================
    // GET CHECKOUT ITEMS
    // ======================================================

    Task<List<ShoppingCartItem>>
        GetCheckoutItemsAsync(
            long shoppingCartId);

    // ======================================================
    // SOFT DELETE ALL ITEMS AFTER CHECKOUT
    // ======================================================

    Task ClearShoppingCartItemsAsync(
        long shoppingCartId);

    // ======================================================
    // UPDATE SHOPPING CART ITEM
    // ======================================================

    Task<bool> UpdateShoppingCartItemAsync(
        UpdateShoppingCartItemDto dto);

    // ======================================================
    // DELETE SHOPPING CART ITEM
    // ======================================================

    Task<bool> DeleteShoppingCartItemAsync(
        long shoppingCartItemId);

    // ======================================================
    // GET SHOPPING CART ITEM
    // ======================================================

    Task<ShoppingCartItemDto?> GetShoppingCartItemByIdAsync(
        long shoppingCartItemId);

    // ======================================================
    // GET SHOPPING CART ITEMS
    // ======================================================

    Task<IEnumerable<ShoppingCartItemDto>>
        GetShoppingCartItemsByCartAsync(
            long shoppingCartId);

    Task<IEnumerable<ShoppingCartItemSummaryDto>>
        GetShoppingCartItemSummariesByCartAsync(
            long shoppingCartId);

    // ======================================================
    // RESTORE SHOPPING CART ITEM
    // ======================================================

    Task<bool> RestoreShoppingCartItemAsync(
        long shoppingCartItemId);

    // ======================================================
    // CHECK EXISTS
    // ======================================================

    Task<bool> ExistsAsync(
        long shoppingCartItemId);
}
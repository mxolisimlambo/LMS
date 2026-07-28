using LMS.Shared.DTOs.Commerce.ShoppingCart.CartItem;

namespace LMS.Application.Interfaces.Commerce;

public interface IShoppingCartItemService
{
    Task<bool> CreateShoppingCartItemAsync(
        CreateShoppingCartItemDto dto);

    Task<bool> UpdateShoppingCartItemAsync(
        UpdateShoppingCartItemDto dto);

    Task<bool> DeleteShoppingCartItemAsync(
        long shoppingCartItemId);

    Task<ShoppingCartItemDto?> GetShoppingCartItemByIdAsync(
        long shoppingCartItemId);

    Task<IEnumerable<ShoppingCartItemDto>>
        GetShoppingCartItemsByCartAsync(
            long shoppingCartId);

    Task<IEnumerable<ShoppingCartItemSummaryDto>>
        GetShoppingCartItemSummariesByCartAsync(
            long shoppingCartId);

    Task<bool> RestoreShoppingCartItemAsync(
        long shoppingCartItemId);

    Task<bool> ExistsAsync(
        long shoppingCartItemId);
}

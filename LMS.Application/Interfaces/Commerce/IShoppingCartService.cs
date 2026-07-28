using LMS.Shared.DTOs.Commerce.ShoppingCart.Cart;

namespace LMS.Application.Interfaces.Commerce;

public interface IShoppingCartService
{
    Task<bool> CreateShoppingCartAsync(
        CreateShoppingCartDto dto);

    Task<bool> UpdateShoppingCartAsync(
        UpdateShoppingCartDto dto);

    Task<bool> DeleteShoppingCartAsync(
        long shoppingCartId);

    Task<ShoppingCartDto?> GetShoppingCartByIdAsync(
        long shoppingCartId);

    Task<ShoppingCartDto?> GetShoppingCartByStudentAsync(
        long studentProfileId);

    Task<IEnumerable<ShoppingCartSummaryDto>>
        GetAllShoppingCartsAsync();

    Task<bool> ClearShoppingCartAsync(
        long shoppingCartId);

    Task<bool> RestoreShoppingCartAsync(
        long shoppingCartId);

    Task<bool> ExistsAsync(
        long shoppingCartId);
}

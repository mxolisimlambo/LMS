using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Commerce.ShoppingCart.CartItem;

public class UpdateShoppingCartItemDto
{
    [Required]
    [Range(1, long.MaxValue)]
    public long ShoppingCartItemId { get; set; }
}

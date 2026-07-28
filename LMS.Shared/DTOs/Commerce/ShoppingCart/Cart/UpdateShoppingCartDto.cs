using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Commerce.ShoppingCart.Cart;

public class UpdateShoppingCartDto
{
    [Required]
    [Range(1, long.MaxValue)]
    public long ShoppingCartId { get; set; }
}

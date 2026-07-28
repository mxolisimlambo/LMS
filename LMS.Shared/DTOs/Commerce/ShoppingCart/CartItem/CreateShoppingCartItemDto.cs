using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Commerce.ShoppingCart.CartItem;

public class CreateShoppingCartItemDto
{
    [Required]
    [Range(1, long.MaxValue)]
    public long ShoppingCartId { get; set; }

    [Required]
    [Range(1, long.MaxValue)]
    public long CourseId { get; set; }
}

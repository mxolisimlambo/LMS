using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Commerce.ShoppingCart.Cart;

public class CreateShoppingCartDto
{
    [Required]
    [Range(1, long.MaxValue)]
    public long StudentProfileId { get; set; }
}

namespace LMS.Shared.DTOs.Commerce.ShoppingCart.Cart;

public class ShoppingCartSummaryDto
{
    public long ShoppingCartId { get; set; }

    public long StudentProfileId { get; set; }

    public int TotalItems { get; set; }

    public decimal TotalAmount { get; set; }
}

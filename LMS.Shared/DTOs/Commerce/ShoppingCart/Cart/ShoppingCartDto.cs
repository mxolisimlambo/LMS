namespace LMS.Shared.DTOs.Commerce.ShoppingCart.Cart;

public class ShoppingCartDto
{
    public long ShoppingCartId { get; set; }

    public long StudentProfileId { get; set; }

    public decimal TotalAmount { get; set; }

    public int TotalItems { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

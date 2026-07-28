namespace LMS.Shared.DTOs.Commerce.ShoppingCart.CartItem;

public class ShoppingCartItemDto
{
    public long ShoppingCartItemId { get; set; }

    public long ShoppingCartId { get; set; }

    public long CourseId { get; set; }

    public string CourseTitle { get; set; } = string.Empty;

    public string? CourseThumbnail { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

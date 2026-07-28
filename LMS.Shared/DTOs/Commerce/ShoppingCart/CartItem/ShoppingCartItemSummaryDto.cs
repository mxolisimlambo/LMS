namespace LMS.Shared.DTOs.Commerce.ShoppingCart.CartItem;

public class ShoppingCartItemSummaryDto
{
    public long ShoppingCartItemId { get; set; }

    public long CourseId { get; set; }

    public string CourseTitle { get; set; } = string.Empty;

    public string? CourseThumbnail { get; set; }

    public decimal TotalPrice { get; set; }
}

using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Commerce.ShoppingCard;

public class ShoppingCartItem
{
    public long ShoppingCartItemId { get; set; }

    public long ShoppingCartId { get; set; }

    public long CourseId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation

    public ShoppingCart? ShoppingCart { get; set; }

    public Course? Course { get; set; }
}

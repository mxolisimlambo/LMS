using LMS.Domain.Entities.Students;

namespace LMS.Domain.Entities.Commerce.ShoppingCard;

public class ShoppingCart
{
    public long ShoppingCartId { get; set; }

    public long StudentProfileId { get; set; }

    public decimal TotalAmount { get; set; }

    public int TotalItems { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation

    public StudentProfile? StudentProfile { get; set; }

    public ICollection<ShoppingCartItem> ShoppingCartItems
        = new List<ShoppingCartItem>();
}

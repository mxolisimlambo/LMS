using LMS.Domain.Entities.Commerce.ShoppingCard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Configurations.Commerce.ShoppingCard;

public class ShoppingCartItemConfiguration
    : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(
        EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.HasKey(x => x.ShoppingCartItemId);

        builder.Property(x => x.UnitPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.DiscountAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.TotalPrice)
            .HasColumnType("decimal(18,2)");

        builder.HasIndex(x => new
        {
            x.ShoppingCartId,
            x.CourseId
        })
        .IsUnique();
        builder.HasOne(x => x.ShoppingCart)
            .WithMany(x => x.ShoppingCartItems)
            .HasForeignKey(x => x.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Course)
            .WithMany(x => x.ShoppingCartItems)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

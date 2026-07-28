using LMS.Domain.Entities.Commerce.ShoppingCard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Configurations.Commerce.ShoppingCard;

public class ShoppingCartConfiguration
    : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(
        EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.HasKey(x => x.ShoppingCartId);

        builder.Property(x => x.TotalAmount)
            .HasColumnType("decimal(18,2)");


        builder.HasIndex(x => x.StudentProfileId)
        .IsUnique();

        builder.HasOne(x => x.StudentProfile)
            .WithOne(x => x.ShoppingCart)
            .HasForeignKey<ShoppingCart>(x => x.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

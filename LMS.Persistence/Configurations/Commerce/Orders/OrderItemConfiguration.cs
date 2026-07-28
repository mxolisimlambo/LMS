using LMS.Domain.Entities.Commerce.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Configurations.Commerce.Orders;

public class OrderItemConfiguration
    : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(
        EntityTypeBuilder<OrderItem> builder)
    {
        // ======================================================
        // PRIMARY KEY
        // ======================================================

        builder.HasKey(x => x.OrderItemId);

        // ======================================================
        // PROPERTIES
        // ======================================================

        builder.Property(x => x.CourseTitle)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.UnitPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.DiscountAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.TotalPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        // ======================================================
        // INDEXES
        // ======================================================

        builder.HasIndex(x => x.OrderId);

        builder.HasIndex(x => x.CourseId);

        // Prevent the same course from being added
        // more than once to the same order.

        builder.HasIndex(x => new
        {
            x.OrderId,
            x.CourseId
        })
        .IsUnique();

        // ======================================================
        // COURSE RELATIONSHIP
        // ======================================================

        builder.HasOne(x => x.Course)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
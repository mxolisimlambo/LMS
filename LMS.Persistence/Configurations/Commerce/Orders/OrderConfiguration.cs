using LMS.Domain.Entities.Commerce.Orders;
using LMS.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Configurations.Commerce.Orders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // ======================================================
        // PRIMARY KEY
        // ======================================================

        builder.HasKey(x => x.OrderId);

        // ======================================================
        // PROPERTIES
        // ======================================================

        builder.Property(x => x.OrderNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.SubTotalAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.DiscountAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.TotalAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Currency)
            .IsRequired()
            .HasMaxLength(10)
            .HasDefaultValue("ZAR");

        builder.Property(x => x.OrderStatus)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue("Pending");

        builder.Property(x => x.OrderDate)
            .IsRequired();

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        // ======================================================
        // INDEXES
        // ======================================================

        builder.HasIndex(x => x.OrderNumber)
            .IsUnique();

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.OrderStatus);

        builder.HasIndex(x => x.OrderDate);

        // ======================================================
        // STUDENT PROFILE RELATIONSHIP
        // ======================================================

        builder.HasOne(x => x.StudentProfile)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        // ======================================================
        // ORDER ITEMS RELATIONSHIP
        // ======================================================

        builder.HasMany(x => x.OrderItems)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
            // ======================================================
// PAYMENT RELATIONSHIP
// ======================================================

builder.HasOne(x => x.Payment)
    .WithOne(x => x.Order)
    .HasForeignKey<Payment>(x => x.OrderId)
    .OnDelete(DeleteBehavior.Restrict);
    }
}
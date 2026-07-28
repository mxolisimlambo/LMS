using LMS.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Payments;

public class RefundConfiguration
    : IEntityTypeConfiguration<Refund>
{
    public void Configure(
        EntityTypeBuilder<Refund> builder)
    {
        builder.ToTable("Refunds");

        builder.HasKey(x => x.RefundId);

        builder.Property(x => x.RefundId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.RefundReference)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.RefundReference)
            .IsUnique();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.RefundReason)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.RefundStatus)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.ApprovedBy)
            .HasMaxLength(450);

        builder.Property(x => x.RejectionReason)
            .HasMaxLength(500);

        builder.Property(x => x.GatewayRefundReference)
            .HasMaxLength(150);

        builder.Property(x => x.RefundAmount)
            .HasPrecision(18, 2);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.PaymentId);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.RefundStatus);

        builder.HasIndex(x => x.RefundDate);

        builder.HasIndex(x => x.IsDeleted);

        builder.HasOne(x => x.Payment)
            .WithMany(x => x.Refunds)
            .HasForeignKey(x => x.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.StudentProfile)
            .WithMany(x => x.Refunds)
            .HasForeignKey(x => x.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

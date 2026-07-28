using LMS.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Payments;

public class PaymentTransactionConfiguration
    : IEntityTypeConfiguration<PaymentTransaction>
{
    public void Configure(
        EntityTypeBuilder<PaymentTransaction> builder)
    {
        builder.ToTable("PaymentTransactions");

        builder.HasKey(x => x.PaymentTransactionId);

        builder.Property(x => x.PaymentTransactionId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.TransactionReference)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.TransactionReference)
            .IsUnique();

        builder.Property(x => x.GatewayTransactionId)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasIndex(x => x.GatewayTransactionId);

        builder.Property(x => x.GatewayName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.TransactionType)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.TransactionStatus)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2);

        builder.Property(x => x.ResponseCode)
            .HasMaxLength(50);

        builder.Property(x => x.ResponseMessage)
            .HasMaxLength(500);

        builder.Property(x => x.FailureReason)
            .HasMaxLength(500);

        builder.Property(x => x.GatewayResponse)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.PaymentId);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.TransactionStatus);

        builder.HasIndex(x => x.TransactionDate);

        builder.HasIndex(x => x.IsDeleted);

        builder.HasOne(x => x.Payment)
            .WithMany(x => x.PaymentTransactions)
            .HasForeignKey(x => x.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.StudentProfile)
            .WithMany(x => x.PaymentTransactions)
            .HasForeignKey(x => x.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

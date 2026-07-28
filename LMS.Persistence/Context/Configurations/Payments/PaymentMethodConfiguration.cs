using LMS.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Payments;

public class PaymentMethodConfiguration
    : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(
        EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.ToTable("PaymentMethods");

        builder.HasKey(x => x.PaymentMethodId);

        builder.Property(x => x.PaymentMethodId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MethodName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.MethodName)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.ProviderName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ProviderCode)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDefault)
            .HasDefaultValue(false);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.ProviderCode);

        builder.HasIndex(x => x.IsActive);

        builder.HasIndex(x => x.IsDeleted);

        builder.HasMany(x => x.Payments)
            .WithOne(x => x.PaymentMethod)
            .HasForeignKey(x => x.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

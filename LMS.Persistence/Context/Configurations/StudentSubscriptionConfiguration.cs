using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class StudentSubscriptionConfiguration
    : IEntityTypeConfiguration<StudentSubscription>
{
    public void Configure(
        EntityTypeBuilder<StudentSubscription> builder)
    {
        builder.ToTable("StudentSubscriptions");

        builder.HasKey(x => x.StudentSubscriptionId);

        builder.Property(x => x.StudentSubscriptionId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.SubscriptionPlanId)
            .IsRequired();

        builder.Property(x => x.Amount)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.AutoRenew)
            .HasDefaultValue(false);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.SubscriptionPlanId);

        builder.HasIndex(x => x.PaymentId);

        builder.HasIndex(x => x.IsActive);

        builder.HasIndex(x => x.IsDeleted);
    }
}
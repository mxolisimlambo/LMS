using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorSubscriptionConfiguration
    : IEntityTypeConfiguration<InstructorSubscription>
{
    public void Configure(
        EntityTypeBuilder<InstructorSubscription> builder)
    {
        builder.ToTable("InstructorSubscriptions");

        builder.HasKey(x => x.InstructorSubscriptionId);

        builder.Property(x => x.InstructorSubscriptionId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.SubscriptionType)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.MonthlyFee)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.Property(x => x.AutoRenew)
            .HasDefaultValue(false);

        builder.Property(x => x.Status)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.SubscriptionType);
    }
}
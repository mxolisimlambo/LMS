using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorAvailabilityConfiguration
    : IEntityTypeConfiguration<InstructorAvailability>
{
    public void Configure(
        EntityTypeBuilder<InstructorAvailability> builder)
    {
        builder.ToTable("InstructorAvailabilities");

        builder.HasKey(x => x.InstructorAvailabilityId);

        builder.Property(x => x.InstructorAvailabilityId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.DayOfWeek)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.StartTime)
            .IsRequired();

        builder.Property(x => x.EndTime)
            .IsRequired();

        builder.Property(x => x.IsAvailable)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.DayOfWeek);

        builder.HasIndex(x => x.IsDeleted);
    }
}
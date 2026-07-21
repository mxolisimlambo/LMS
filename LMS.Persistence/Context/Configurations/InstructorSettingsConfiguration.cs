using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorSettingsConfiguration
    : IEntityTypeConfiguration<InstructorSettings>
{
    public void Configure(
        EntityTypeBuilder<InstructorSettings> builder)
    {
        builder.ToTable("InstructorSettings");

        builder.HasKey(x => x.InstructorSettingsId);

        builder.Property(x => x.InstructorSettingsId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.AllowPublicProfile)
            .HasDefaultValue(true);

        builder.Property(x => x.AllowCourseReviews)
            .HasDefaultValue(true);

        builder.Property(x => x.ShowRevenue)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasIndex(x => x.InstructorProfileId);
    }
}
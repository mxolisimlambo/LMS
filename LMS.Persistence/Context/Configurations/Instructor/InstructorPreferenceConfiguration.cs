using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Instructor;

public class InstructorPreferenceConfiguration
    : IEntityTypeConfiguration<InstructorPreference>
{
    public void Configure(
        EntityTypeBuilder<InstructorPreference> builder)
    {
        builder.ToTable("InstructorPreferences");

        builder.HasKey(x => x.InstructorPreferenceId);

        builder.Property(x => x.InstructorPreferenceId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.Language)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.TimeZone)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(x => x.InstructorProfileId);
    }
}
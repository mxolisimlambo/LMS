using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorExperienceConfiguration
    : IEntityTypeConfiguration<InstructorExperience>
{
    public void Configure(
        EntityTypeBuilder<InstructorExperience> builder)
    {
        builder.ToTable("InstructorExperiences");

        builder.HasKey(x => x.InstructorExperienceId);

        builder.Property(x => x.InstructorExperienceId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.Company)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Position)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.Company);

        builder.HasIndex(x => x.IsDeleted);
    }
}
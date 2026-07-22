using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Instructor;

public class InstructorSkillConfiguration
    : IEntityTypeConfiguration<InstructorSkill>
{
    public void Configure(
        EntityTypeBuilder<InstructorSkill> builder)
    {
        builder.ToTable("InstructorSkills");

        builder.HasKey(x => x.InstructorSkillId);

        builder.Property(x => x.InstructorSkillId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.SkillName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.YearsExperience)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.SkillName);

        builder.HasIndex(x => x.IsDeleted);
    }
}
using LMS.Domain.Entities.Courses.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Catalog;

public class CourseLevelConfiguration
    : IEntityTypeConfiguration<CourseLevel>
{
    public void Configure(
        EntityTypeBuilder<CourseLevel> builder)
    {
        builder.ToTable("CourseLevels");

        builder.HasKey(x => x.CourseLevelId);

        builder.Property(x => x.CourseLevelId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.LevelName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.LevelName)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .HasDefaultValue(0);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.DisplayOrder);

        builder.HasIndex(x => x.IsActive);

        builder.HasIndex(x => x.IsDeleted);

        //==========================
        // One-to-Many
        //==========================

        builder.HasMany(x => x.Courses)
            .WithOne(x => x.CourseLevel)
            .HasForeignKey(x => x.CourseLevelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using LMS.Domain.Entities.Courses.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Content;

public class CourseModuleConfiguration
    : IEntityTypeConfiguration<CourseModule>
{
    public void Configure(
        EntityTypeBuilder<CourseModule> builder)
    {
        builder.ToTable("CourseModules");

        builder.HasKey(x => x.CourseModuleId);

        builder.Property(x => x.CourseModuleId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.ModuleTitle)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .HasDefaultValue(0);

        builder.Property(x => x.DurationHours)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.IsPublished)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.DisplayOrder);

        builder.HasIndex(x => x.IsPublished);

        builder.HasIndex(x => x.IsDeleted);

        //==========================
        // One-to-Many
        //==========================

        builder.HasMany(x => x.CourseLessons)
            .WithOne(x => x.CourseModule)
            .HasForeignKey(x => x.CourseModuleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
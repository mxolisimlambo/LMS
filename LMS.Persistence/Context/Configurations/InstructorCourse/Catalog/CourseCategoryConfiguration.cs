using LMS.Domain.Entities.Courses.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Catalog;

public class CourseCategoryConfiguration
    : IEntityTypeConfiguration<CourseCategory>
{
    public void Configure(
        EntityTypeBuilder<CourseCategory> builder)
    {
        builder.ToTable("CourseCategories");

        builder.HasKey(x => x.CourseCategoryId);

        builder.Property(x => x.CourseCategoryId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CategoryName)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasIndex(x => x.CategoryName)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Icon)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .HasDefaultValue(0);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.IsActive);

        builder.HasIndex(x => x.DisplayOrder);

        builder.HasIndex(x => x.IsDeleted);

        //==========================
        // One-to-Many
        //==========================

        builder.HasMany(x => x.CourseSubCategories)
            .WithOne(x => x.CourseCategory)
            .HasForeignKey(x => x.CourseCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Courses)
            .WithOne(x => x.CourseCategory)
            .HasForeignKey(x => x.CourseCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
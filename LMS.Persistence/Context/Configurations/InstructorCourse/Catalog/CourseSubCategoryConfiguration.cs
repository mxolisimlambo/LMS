using LMS.Domain.Entities.Courses.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Catalog;

public class CourseSubCategoryConfiguration
    : IEntityTypeConfiguration<CourseSubCategory>
{
    public void Configure(
        EntityTypeBuilder<CourseSubCategory> builder)
    {
        builder.ToTable("CourseSubCategories");

        builder.HasKey(x => x.CourseSubCategoryId);

        builder.Property(x => x.CourseSubCategoryId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseCategoryId)
            .IsRequired();

        builder.Property(x => x.SubCategoryName)
            .HasMaxLength(150)
            .IsRequired();

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

        builder.HasIndex(x => x.CourseCategoryId);

        builder.HasIndex(x => new
        {
            x.CourseCategoryId,
            x.SubCategoryName
        }).IsUnique();

        builder.HasIndex(x => x.DisplayOrder);

        builder.HasIndex(x => x.IsActive);

        builder.HasIndex(x => x.IsDeleted);

        //==========================
        // One-to-Many
        //==========================

        builder.HasOne(x => x.CourseCategory)
            .WithMany(x => x.CourseSubCategories)
            .HasForeignKey(x => x.CourseCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Courses)
            .WithOne(x => x.CourseSubCategory)
            .HasForeignKey(x => x.CourseSubCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
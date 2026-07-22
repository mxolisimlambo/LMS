using LMS.Domain.Entities.Courses.Catalog;
using LMS.Domain.Entities.Courses.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Catalog;

public class CourseConfiguration
    : IEntityTypeConfiguration<Course>
{
    public void Configure(
        EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(x => x.CourseId);

        builder.Property(x => x.CourseId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.CourseCategoryId)
            .IsRequired();

        builder.Property(x => x.CourseSubCategoryId)
            .IsRequired();

        builder.Property(x => x.CourseLevelId)
            .IsRequired();

        builder.Property(x => x.CourseLanguageId)
            .IsRequired();

        builder.Property(x => x.CourseStatusId)
            .IsRequired();

        builder.Property(x => x.CourseCode)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(x => x.CourseCode)
            .IsUnique();

        builder.Property(x => x.Title)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(x => x.Subtitle)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.Thumbnail)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.PreviewVideo)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.DurationHours)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.EstimatedStudyHours)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.MaximumStudents)
            .IsRequired();

        builder.Property(x => x.MinimumStudents)
            .IsRequired();

        builder.Property(x => x.IsFeatured)
            .HasDefaultValue(false);

        builder.Property(x => x.IsPremium)
            .HasDefaultValue(false);

        builder.Property(x => x.IsPublished)
            .HasDefaultValue(false);

        builder.Property(x => x.PublishedBy)
            .HasMaxLength(450);

        builder.Property(x => x.ApprovedBy)
            .HasMaxLength(450);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.CourseCategoryId);

        builder.HasIndex(x => x.CourseSubCategoryId);

        builder.HasIndex(x => x.CourseLevelId);

        builder.HasIndex(x => x.CourseLanguageId);

        builder.HasIndex(x => x.CourseStatusId);

        builder.HasIndex(x => x.IsFeatured);

        builder.HasIndex(x => x.IsPremium);

        builder.HasIndex(x => x.IsPublished);

        builder.HasIndex(x => x.IsDeleted);

        //==========================
        // One-to-One
        //==========================

        builder.HasOne(x => x.CoursePrice)
            .WithOne(x => x.Course)
            .HasForeignKey<CoursePrice>(
                x => x.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        //==========================
        // One-to-Many
        //==========================

        builder.HasMany(x => x.CourseTags)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.CourseRequirements)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.CourseOutcomes)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.CourseTargetAudiences)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.CourseFAQs)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.CourseDiscounts)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.CourseCoupons)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
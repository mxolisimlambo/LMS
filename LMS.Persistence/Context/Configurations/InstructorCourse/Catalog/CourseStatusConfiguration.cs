using LMS.Domain.Entities.Courses.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Catalog;

public class CourseStatusConfiguration
    : IEntityTypeConfiguration<CourseStatus>
{
    public void Configure(
        EntityTypeBuilder<CourseStatus> builder)
    {
        builder.ToTable("CourseStatuses");

        builder.HasKey(x => x.CourseStatusId);

        builder.Property(x => x.CourseStatusId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StatusName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.StatusName)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.IsActive);

        builder.HasIndex(x => x.IsDeleted);

        //==========================
        // One-to-Many
        //==========================

        builder.HasMany(x => x.Courses)
            .WithOne(x => x.CourseStatus)
            .HasForeignKey(x => x.CourseStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
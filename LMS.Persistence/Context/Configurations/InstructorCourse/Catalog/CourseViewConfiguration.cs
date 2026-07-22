using LMS.Domain.Entities.Courses.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Catalog;

public class CourseViewConfiguration
    : IEntityTypeConfiguration<CourseView>
{
    public void Configure(
        EntityTypeBuilder<CourseView> builder)
    {
        builder.ToTable("CourseViews");

        builder.HasKey(x => x.CourseViewId);

        builder.Property(x => x.CourseViewId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.IpAddress)
            .HasMaxLength(45);

        builder.Property(x => x.DeviceType)
            .HasMaxLength(100);

        builder.Property(x => x.Browser)
            .HasMaxLength(100);

        builder.Property(x => x.OperatingSystem)
            .HasMaxLength(100);

        builder.Property(x => x.ViewedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.ViewedDate);

        builder.HasIndex(x => x.IsDeleted);
    }
}
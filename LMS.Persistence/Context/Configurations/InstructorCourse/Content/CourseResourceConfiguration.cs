using LMS.Domain.Entities.Courses.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Content;

public class CourseResourceConfiguration
    : IEntityTypeConfiguration<CourseResource>
{
    public void Configure(
        EntityTypeBuilder<CourseResource> builder)
    {
        builder.ToTable("CourseResources");

        builder.HasKey(x => x.CourseResourceId);

        builder.Property(x => x.CourseResourceId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.ResourceName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.ResourceUrl)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .HasDefaultValue(0);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.DisplayOrder);

        builder.HasIndex(x => x.IsDeleted);
    }
}
using LMS.Domain.Entities.Courses.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Catalog;

public class CourseTagConfiguration
    : IEntityTypeConfiguration<CourseTag>
{
    public void Configure(
        EntityTypeBuilder<CourseTag> builder)
    {
        builder.ToTable("CourseTags");

        builder.HasKey(x => x.CourseTagId);

        builder.Property(x => x.CourseTagId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.TagName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => new
        {
            x.CourseId,
            x.TagName
        }).IsUnique();

        builder.HasIndex(x => x.IsDeleted);
    }
}
using LMS.Domain.Entities.Courses.Publishing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Publishing;

public class CoursePublishingConfiguration
    : IEntityTypeConfiguration<CoursePublishing>
{
    public void Configure(
        EntityTypeBuilder<CoursePublishing> builder)
    {
        builder.ToTable("CoursePublishing");

        builder.HasKey(x => x.CoursePublishingId);

        builder.Property(x => x.CoursePublishingId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.IsPublished)
            .HasDefaultValue(false);

        builder.Property(x => x.PublishedBy)
            .HasMaxLength(450);

        builder.Property(x => x.UnpublishedReason)
            .HasMaxLength(1000);

        builder.Property(x => x.AllowEnrollment)
            .HasDefaultValue(true);

        builder.Property(x => x.AllowPreview)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId)
            .IsUnique();

        builder.HasIndex(x => x.IsPublished);

        builder.HasIndex(x => x.AllowEnrollment);

        builder.HasIndex(x => x.IsDeleted);
    }
}
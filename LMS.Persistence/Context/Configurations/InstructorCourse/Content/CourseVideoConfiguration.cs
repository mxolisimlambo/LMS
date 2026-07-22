using LMS.Domain.Entities.Courses.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Content;

public class CourseVideoConfiguration
    : IEntityTypeConfiguration<CourseVideo>
{
    public void Configure(
        EntityTypeBuilder<CourseVideo> builder)
    {
        builder.ToTable("CourseVideos");

        builder.HasKey(x => x.CourseVideoId);

        builder.Property(x => x.CourseVideoId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseLessonId)
            .IsRequired();

        builder.Property(x => x.VideoTitle)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.VideoUrl)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Thumbnail)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.DurationMinutes)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.FileSize)
            .IsRequired();

        builder.Property(x => x.IsDownloadable)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseLessonId);

        builder.HasIndex(x => x.IsDownloadable);

        builder.HasIndex(x => x.IsDeleted);
    }
}
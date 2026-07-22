using LMS.Domain.Entities.Courses.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Content;

public class CourseAttachmentConfiguration
    : IEntityTypeConfiguration<CourseAttachment>
{
    public void Configure(
        EntityTypeBuilder<CourseAttachment> builder)
    {
        builder.ToTable("CourseAttachments");

        builder.HasKey(x => x.CourseAttachmentId);

        builder.Property(x => x.CourseAttachmentId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseLessonId)
            .IsRequired();

        builder.Property(x => x.AttachmentTitle)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.FilePath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.FileType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.FileSize)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseLessonId);

        builder.HasIndex(x => x.FileType);

        builder.HasIndex(x => x.IsDeleted);
    }
}
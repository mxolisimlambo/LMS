using LMS.Domain.Entities.Courses.Publishing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Publishing;

public class CourseAnnouncementConfiguration
    : IEntityTypeConfiguration<CourseAnnouncement>
{
    public void Configure(
        EntityTypeBuilder<CourseAnnouncement> builder)
    {
        builder.ToTable("CourseAnnouncements");

        builder.HasKey(x => x.CourseAnnouncementId);

        builder.Property(x => x.CourseAnnouncementId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Message)
            .HasMaxLength(4000)
            .IsRequired();

        builder.Property(x => x.NotifyStudentsByEmail)
            .HasDefaultValue(false);

        builder.Property(x => x.NotifyStudentsInApp)
            .HasDefaultValue(true);

        builder.Property(x => x.PublishDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.PublishDate);

        builder.HasIndex(x => x.IsDeleted);
    }
}
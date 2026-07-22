using LMS.Domain.Entities.Courses.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Content;

public class CourseLessonConfiguration
    : IEntityTypeConfiguration<CourseLesson>
{
    public void Configure(
        EntityTypeBuilder<CourseLesson> builder)
    {
        builder.ToTable("CourseLessons");

        builder.HasKey(x => x.CourseLessonId);

        builder.Property(x => x.CourseLessonId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseModuleId)
            .IsRequired();

        builder.Property(x => x.LessonTitle)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .HasDefaultValue(0);

        builder.Property(x => x.DurationMinutes)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.IsPreview)
            .HasDefaultValue(false);

        builder.Property(x => x.IsPublished)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseModuleId);

        builder.HasIndex(x => x.DisplayOrder);

        builder.HasIndex(x => x.IsPreview);

        builder.HasIndex(x => x.IsPublished);

        builder.HasIndex(x => x.IsDeleted);

        //==========================
        // One-to-Many
        //==========================

        builder.HasMany(x => x.CourseVideos)
            .WithOne(x => x.CourseLesson)
            .HasForeignKey(x => x.CourseLessonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.CourseDocuments)
            .WithOne(x => x.CourseLesson)
            .HasForeignKey(x => x.CourseLessonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.CourseAttachments)
            .WithOne(x => x.CourseLesson)
            .HasForeignKey(x => x.CourseLessonId)
            .OnDelete(DeleteBehavior.Restrict);

       
    }
}
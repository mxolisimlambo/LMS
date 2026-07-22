using LMS.Domain.Entities.Courses.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Catalog;

public class CourseLanguageConfiguration
    : IEntityTypeConfiguration<CourseLanguage>
{
    public void Configure(
        EntityTypeBuilder<CourseLanguage> builder)
    {
        builder.ToTable("CourseLanguages");

        builder.HasKey(x => x.CourseLanguageId);

        builder.Property(x => x.CourseLanguageId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.LanguageName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.LanguageName)
            .IsUnique();

        builder.Property(x => x.LanguageCode)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => x.LanguageCode)
            .IsUnique();

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
            .WithOne(x => x.CourseLanguage)
            .HasForeignKey(x => x.CourseLanguageId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using LMS.Domain.Entities.Courses.Publishing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Publishing;

public class CourseVisibilityConfiguration
    : IEntityTypeConfiguration<CourseVisibility>
{
    public void Configure(
        EntityTypeBuilder<CourseVisibility> builder)
    {
        builder.ToTable("CourseVisibility");

        builder.HasKey(x => x.CourseVisibilityId);

        builder.Property(x => x.CourseVisibilityId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.IsPublic)
            .HasDefaultValue(true);

        builder.Property(x => x.IsPrivate)
            .HasDefaultValue(false);

        builder.Property(x => x.IsUnlisted)
            .HasDefaultValue(false);

        builder.Property(x => x.FeaturedOnHomepage)
            .HasDefaultValue(false);

        builder.Property(x => x.AllowSearchEngineIndexing)
            .HasDefaultValue(true);

        builder.Property(x => x.VisibleInMarketplace)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId)
            .IsUnique();

        builder.HasIndex(x => x.IsPublic);

        builder.HasIndex(x => x.IsPrivate);

        builder.HasIndex(x => x.IsUnlisted);

        builder.HasIndex(x => x.FeaturedOnHomepage);

        builder.HasIndex(x => x.VisibleInMarketplace);

        builder.HasIndex(x => x.IsDeleted);
    }
}
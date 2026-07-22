using LMS.Domain.Entities.Courses.Analytics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse;

public class CourseStatisticsConfiguration
    : IEntityTypeConfiguration<CourseStatistics>
{
    public void Configure(
        EntityTypeBuilder<CourseStatistics> builder)
    {
        builder.ToTable("CourseStatistics");

        builder.HasKey(x => x.CourseStatisticsId);

        builder.Property(x => x.CourseStatisticsId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.TotalViews)
            .HasDefaultValue(0);

        builder.Property(x => x.TotalEnrollments)
            .HasDefaultValue(0);

        builder.Property(x => x.TotalCompletions)
            .HasDefaultValue(0);

        builder.Property(x => x.TotalReviews)
            .HasDefaultValue(0);

        builder.Property(x => x.AverageRating)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(x => x.TotalWishlist)
            .HasDefaultValue(0);

        builder.Property(x => x.TotalRevenue)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(x => x.LastUpdatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId)
            .IsUnique();

        builder.HasIndex(x => x.IsDeleted);
    }
}
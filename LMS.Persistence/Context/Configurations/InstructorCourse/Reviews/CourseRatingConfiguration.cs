using LMS.Domain.Entities.Courses.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Reviews;

public class CourseRatingConfiguration
    : IEntityTypeConfiguration<CourseRating>
{
    public void Configure(
        EntityTypeBuilder<CourseRating> builder)
    {
        builder.ToTable("CourseRatings");

        builder.HasKey(x => x.CourseRatingId);

        builder.Property(x => x.CourseRatingId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.Rating)
            .HasColumnType("decimal(3,2)")
            .IsRequired();

        builder.Property(x => x.IsVerifiedPurchase)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.IsVerifiedPurchase);

        builder.HasIndex(x => x.IsDeleted);

        builder.HasIndex(x => new
        {
            x.CourseId,
            x.StudentProfileId
        }).IsUnique();
    }
}
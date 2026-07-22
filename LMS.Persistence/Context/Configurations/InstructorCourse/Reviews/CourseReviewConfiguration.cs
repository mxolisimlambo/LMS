using LMS.Domain.Entities.Courses.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Reviews;

public class CourseReviewConfiguration
    : IEntityTypeConfiguration<CourseReview>
{
    public void Configure(
        EntityTypeBuilder<CourseReview> builder)
    {
        builder.ToTable("CourseReviews");

        builder.HasKey(x => x.CourseReviewId);

        builder.Property(x => x.CourseReviewId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.ReviewTitle)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Review)
            .HasMaxLength(4000)
            .IsRequired();

        builder.Property(x => x.IsRecommended)
            .HasDefaultValue(false);

        builder.Property(x => x.IsApproved)
            .HasDefaultValue(false);

        builder.Property(x => x.ApprovedBy)
            .HasMaxLength(450);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.IsApproved);

        builder.HasIndex(x => x.IsDeleted);

        builder.HasIndex(x => new
        {
            x.CourseId,
            x.StudentProfileId
        });
    }
}
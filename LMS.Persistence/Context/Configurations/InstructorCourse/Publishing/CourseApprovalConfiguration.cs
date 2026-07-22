using LMS.Domain.Entities.Courses.Publishing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Publishing;

public class CourseApprovalConfiguration
    : IEntityTypeConfiguration<CourseApproval>
{
    public void Configure(
        EntityTypeBuilder<CourseApproval> builder)
    {
        builder.ToTable("CourseApprovals");

        builder.HasKey(x => x.CourseApprovalId);

        builder.Property(x => x.CourseApprovalId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.ApprovalStatus)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.ApprovedBy)
            .HasMaxLength(450);

        builder.Property(x => x.RejectedBy)
            .HasMaxLength(450);

        builder.Property(x => x.RejectionReason)
            .HasMaxLength(1000);

        builder.Property(x => x.ReviewComments)
            .HasMaxLength(4000);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId)
            .IsUnique();

        builder.HasIndex(x => x.ApprovalStatus);

        builder.HasIndex(x => x.IsDeleted);
    }
}
using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorApprovalConfiguration
    : IEntityTypeConfiguration<InstructorApproval>
{
    public void Configure(
        EntityTypeBuilder<InstructorApproval> builder)
    {
        builder.ToTable("InstructorApprovals");

        builder.HasKey(x => x.InstructorApprovalId);

        builder.Property(x => x.InstructorApprovalId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.ApprovalStatus)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.ApprovedByUserId)
            .HasMaxLength(450);

        builder.Property(x => x.RejectionReason)
            .HasMaxLength(500);

        builder.Property(x => x.Notes)
            .HasMaxLength(1000);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.ApprovalStatus);

        builder.HasIndex(x => x.IsDeleted);
    }
}
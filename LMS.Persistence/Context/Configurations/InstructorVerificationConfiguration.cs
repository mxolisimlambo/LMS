using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorVerificationConfiguration
    : IEntityTypeConfiguration<InstructorVerification>
{
    public void Configure(
        EntityTypeBuilder<InstructorVerification> builder)
    {
        builder.ToTable("InstructorVerifications");

        builder.HasKey(x => x.InstructorVerificationId);

        builder.Property(x => x.InstructorVerificationId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.VerifiedBy)
            .HasMaxLength(450);

        builder.Property(x => x.Notes)
            .HasMaxLength(1000);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.Status);
    }
}
using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Instructor;

public class InstructorCertificationConfiguration
    : IEntityTypeConfiguration<InstructorCertification>
{
    public void Configure(
        EntityTypeBuilder<InstructorCertification> builder)
    {
        builder.ToTable("InstructorCertifications");

        builder.HasKey(x => x.InstructorCertificationId);

        builder.Property(x => x.InstructorCertificationId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.CertificationName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.IssuingOrganization)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.IssueDate)
            .IsRequired();

        builder.Property(x => x.CertificateNumber)
            .HasMaxLength(100);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.CertificationName);

        builder.HasIndex(x => x.IsDeleted);
    }
}
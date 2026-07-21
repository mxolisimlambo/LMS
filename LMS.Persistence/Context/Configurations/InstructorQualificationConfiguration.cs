using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorQualificationConfiguration
    : IEntityTypeConfiguration<InstructorQualification>
{
    public void Configure(
        EntityTypeBuilder<InstructorQualification> builder)
    {
        builder.ToTable("InstructorQualifications");

        builder.HasKey(x => x.InstructorQualificationId);

        builder.Property(x => x.InstructorQualificationId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.QualificationName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Institution)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Country)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.CompletedYear)
            .IsRequired();

        builder.Property(x => x.CertificateFile)
            .HasMaxLength(500);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.CompletedYear);

        builder.HasIndex(x => x.IsDeleted);
    }
}
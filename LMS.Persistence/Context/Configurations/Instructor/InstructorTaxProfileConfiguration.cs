using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Instructor;

public class InstructorTaxProfileConfiguration
    : IEntityTypeConfiguration<InstructorTaxProfile>
{
    public void Configure(
        EntityTypeBuilder<InstructorTaxProfile> builder)
    {
        builder.ToTable("InstructorTaxProfiles");

        builder.HasKey(x => x.InstructorTaxProfileId);

        builder.Property(x => x.InstructorTaxProfileId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.TaxNumber)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.VatNumber)
            .HasMaxLength(100);

        builder.Property(x => x.Country)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.TaxStatus)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.TaxNumber);

        builder.HasIndex(x => x.TaxStatus);

        builder.HasIndex(x => x.IsDeleted);
    }
}
using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Student;

public class StudentAddressConfiguration
    : IEntityTypeConfiguration<StudentAddress>
{
    public void Configure(
        EntityTypeBuilder<StudentAddress> builder)
    {
        builder.ToTable("StudentAddresses");

        builder.HasKey(x => x.StudentAddressId);

        builder.Property(x => x.StudentAddressId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.AddressLine1)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.AddressLine2)
            .HasMaxLength(200);

        builder.Property(x => x.City)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.StateProvince)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PostalCode)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsPrimary)
            .HasDefaultValue(false);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.CountryId);

        builder.HasIndex(x => x.IsPrimary);

        builder.HasIndex(x => x.IsDeleted);
    }
}

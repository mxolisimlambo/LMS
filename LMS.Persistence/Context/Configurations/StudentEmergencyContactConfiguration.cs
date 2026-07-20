using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class StudentEmergencyContactConfiguration
    : IEntityTypeConfiguration<StudentEmergencyContact>
{
    public void Configure(
        EntityTypeBuilder<StudentEmergencyContact> builder)
    {
        builder.ToTable("StudentEmergencyContacts");

        builder.HasKey(x => x.StudentEmergencyContactId);

        builder.Property(x => x.StudentEmergencyContactId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.FullName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Relationship)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.AlternativePhoneNumber)
            .HasMaxLength(30);

        builder.Property(x => x.EmailAddress)
            .HasMaxLength(200);

        builder.Property(x => x.IsPrimary)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.IsPrimary);

        builder.HasIndex(x => x.IsDeleted);
    }
}

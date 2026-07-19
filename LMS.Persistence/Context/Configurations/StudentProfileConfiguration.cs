using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class StudentProfileConfiguration
    : IEntityTypeConfiguration<StudentProfile>
{
    public void Configure(
        EntityTypeBuilder<StudentProfile> builder)
    {
        builder.ToTable("StudentProfiles");

        builder.HasKey(x => x.StudentProfileId);

        builder.Property(x => x.StudentProfileId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(x => x.StudentNumber)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(x => x.StudentNumber)
            .IsUnique();

        builder.Property(x => x.Occupation)
            .HasMaxLength(200);

        builder.Property(x => x.Company)
            .HasMaxLength(200);

        builder.Property(x => x.ProfilePhoto)
            .HasMaxLength(500);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsPremium)
            .HasDefaultValue(false);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.UserId);

        builder.HasIndex(x => x.IsPremium);

        builder.HasIndex(x => x.IsDeleted);
    }
}
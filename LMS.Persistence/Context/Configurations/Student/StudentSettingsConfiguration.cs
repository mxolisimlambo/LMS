using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Student;

public class StudentSettingsConfiguration
    : IEntityTypeConfiguration<StudentSettings>
{
    public void Configure(
        EntityTypeBuilder<StudentSettings> builder)
    {
        builder.ToTable("StudentSettings");

        builder.HasKey(x => x.StudentSettingsId);

        builder.Property(x => x.StudentSettingsId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.ProfileVisible)
            .HasDefaultValue(true);

        builder.Property(x => x.ShowEmail)
            .HasDefaultValue(false);

        builder.Property(x => x.ShowPhoneNumber)
            .HasDefaultValue(false);

        builder.Property(x => x.TwoFactorEnabled)
            .HasDefaultValue(false);

        builder.Property(x => x.AllowPublicProfile)
            .HasDefaultValue(true);

        builder.Property(x => x.AllowDirectMessages)
            .HasDefaultValue(true);

        builder.Property(x => x.RememberLastLogin)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.IsDeleted);
    }
}

using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class StudentPreferenceConfiguration
    : IEntityTypeConfiguration<StudentPreference>
{
    public void Configure(
        EntityTypeBuilder<StudentPreference> builder)
    {
        builder.ToTable("StudentPreferences");

        builder.HasKey(x => x.StudentPreferenceId);

        builder.Property(x => x.StudentPreferenceId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.Language)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.TimeZone)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Theme)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.EmailNotifications)
            .HasDefaultValue(true);

        builder.Property(x => x.SmsNotifications)
            .HasDefaultValue(false);

        builder.Property(x => x.PushNotifications)
            .HasDefaultValue(true);

        builder.Property(x => x.MarketingEmails)
            .HasDefaultValue(false);

        builder.Property(x => x.MarketingSms)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.IsDeleted);
    }
}
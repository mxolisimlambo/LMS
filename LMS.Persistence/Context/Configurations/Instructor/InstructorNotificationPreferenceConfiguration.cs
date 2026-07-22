using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Instructor;

public class InstructorNotificationPreferenceConfiguration
    : IEntityTypeConfiguration<InstructorNotificationPreference>
{
    public void Configure(
        EntityTypeBuilder<InstructorNotificationPreference> builder)
    {
        builder.ToTable("InstructorNotificationPreferences");

        builder.HasKey(x => x.InstructorNotificationPreferenceId);

        builder.Property(x => x.InstructorNotificationPreferenceId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.EmailNotifications)
            .HasDefaultValue(true);

        builder.Property(x => x.SmsNotifications)
            .HasDefaultValue(false);

        builder.Property(x => x.PushNotifications)
            .HasDefaultValue(true);

        builder.HasIndex(x => x.InstructorProfileId);
    }
}
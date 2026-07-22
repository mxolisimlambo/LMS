using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Student;

public class StudentNotificationPreferenceConfiguration
    : IEntityTypeConfiguration<StudentNotificationPreference>
{
    public void Configure(
        EntityTypeBuilder<StudentNotificationPreference> builder)
    {
        builder.ToTable("StudentNotificationPreferences");

        builder.HasKey(x => x.StudentNotificationPreferenceId);

        builder.Property(x => x.StudentNotificationPreferenceId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.CourseAnnouncements)
            .HasDefaultValue(true);

        builder.Property(x => x.AssignmentReminders)
            .HasDefaultValue(true);

        builder.Property(x => x.QuizReminders)
            .HasDefaultValue(true);

        builder.Property(x => x.PaymentNotifications)
            .HasDefaultValue(true);

        builder.Property(x => x.CertificateNotifications)
            .HasDefaultValue(true);

        builder.Property(x => x.InstructorMessages)
            .HasDefaultValue(true);

        builder.Property(x => x.MarketingNotifications)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.IsDeleted);
    }
}

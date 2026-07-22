using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Student;

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

        builder.HasOne(x => x.StudentPreference)
        .WithOne(x => x.StudentProfile)
        .HasForeignKey<StudentPreference>(
           x => x.StudentProfileId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.StudentSettings)
        .WithOne(x => x.StudentProfile)
        .HasForeignKey<StudentSettings>(
            x => x.StudentProfileId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.StudentNotificationPreference)
        .WithOne(x => x.StudentProfile)
        .HasForeignKey<StudentNotificationPreference>(
            x => x.StudentProfileId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.StudentSubscription)
        .WithOne(x => x.StudentProfile)
        .HasForeignKey<StudentSubscription>(
            x => x.StudentProfileId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.StudentAddresses)
        .WithOne(x => x.StudentProfile)
        .HasForeignKey(x => x.StudentProfileId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.StudentDocuments)
        .WithOne(x => x.StudentProfile)
        .HasForeignKey(x => x.StudentProfileId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.StudentEmergencyContacts)
        .WithOne(x => x.StudentProfile)
        .HasForeignKey(x => x.StudentProfileId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.StudentWishlists)
        .WithOne(x => x.StudentProfile)
        .HasForeignKey(x => x.StudentProfileId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}

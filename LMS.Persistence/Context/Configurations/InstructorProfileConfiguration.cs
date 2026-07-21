using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorProfileConfiguration
    : IEntityTypeConfiguration<InstructorProfile>
{
    public void Configure(
        EntityTypeBuilder<InstructorProfile> builder)
    {
        builder.ToTable("InstructorProfiles");

        builder.HasKey(x => x.InstructorProfileId);

        builder.Property(x => x.InstructorProfileId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(x => x.InstructorNumber)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(x => x.InstructorNumber)
            .IsUnique();

        builder.Property(x => x.ProfessionalHeadline)
            .HasMaxLength(200);

        builder.Property(x => x.Website)
            .HasMaxLength(300);

        builder.Property(x => x.ProfilePhoto)
            .HasMaxLength(500);

        builder.Property(x => x.BannerImage)
            .HasMaxLength(500);

        builder.Property(x => x.ApprovalStatus)
            .HasMaxLength(50);

        builder.Property(x => x.VerificationStatus)
            .HasMaxLength(50);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.UserId);

        builder.HasIndex(x => x.IsPremium);

        builder.HasIndex(x => x.IsDeleted);

        //==========================
        // One-to-One
        //==========================

        builder.HasOne(x => x.InstructorSettings)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey<InstructorSettings>(
                x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InstructorPreference)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey<InstructorPreference>(
                x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InstructorNotificationPreference)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey<InstructorNotificationPreference>(
                x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InstructorSubscription)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey<InstructorSubscription>(
                x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InstructorVerification)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey<InstructorVerification>(
                x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InstructorTaxProfile)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey<InstructorTaxProfile>(
                x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InstructorAvailability)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey<InstructorAvailability>(
                x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InstructorApproval)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey<InstructorApproval>(
                x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InstructorWallet)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey<InstructorWallet>(
                x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        //==========================
        // One-to-Many
        //==========================

        builder.HasMany(x => x.InstructorQualifications)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey(x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.InstructorExperiences)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey(x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.InstructorSkills)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey(x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.InstructorCertifications)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey(x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.InstructorAddresses)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey(x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.InstructorDocuments)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey(x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.InstructorBankAccounts)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey(x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.InstructorSocialLinks)
            .WithOne(x => x.InstructorProfile)
            .HasForeignKey(x => x.InstructorProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
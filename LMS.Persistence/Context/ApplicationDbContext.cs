using LMS.Domain.Entities.Students;
using LMS.Domain.Entities.Instructors;
using LMS.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // ==========================================
    // Student Module
    // ==========================================

    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
    public DbSet<StudentAddress> StudentAddresses => Set<StudentAddress>();
    public DbSet<StudentSubscription> StudentSubscriptions => Set<StudentSubscription>();
    public DbSet<StudentPreference> StudentPreferences => Set<StudentPreference>();
    public DbSet<StudentEmergencyContact> StudentEmergencyContacts => Set<StudentEmergencyContact>();
    public DbSet<StudentWishlist> StudentWishlists => Set<StudentWishlist>();
    public DbSet<StudentDocument> StudentDocuments => Set<StudentDocument>();
    public DbSet<StudentNotificationPreference> StudentNotificationPreferences => Set<StudentNotificationPreference>();
    public DbSet<StudentSettings> StudentSettings => Set<StudentSettings>();

    // ==========================================
    // Instructor Module
    // ==========================================

    public DbSet<InstructorProfile> InstructorProfiles => Set<InstructorProfile>();
public DbSet<InstructorQualification> InstructorQualifications => Set<InstructorQualification>();
public DbSet<InstructorExperience> InstructorExperiences => Set<InstructorExperience>();
public DbSet<InstructorSkill> InstructorSkills => Set<InstructorSkill>();
public DbSet<InstructorCertification> InstructorCertifications => Set<InstructorCertification>();
public DbSet<InstructorAddress> InstructorAddresses => Set<InstructorAddress>();
public DbSet<InstructorDocument> InstructorDocuments => Set<InstructorDocument>();
public DbSet<InstructorVerification> InstructorVerifications => Set<InstructorVerification>();
public DbSet<InstructorSubscription> InstructorSubscriptions => Set<InstructorSubscription>();
public DbSet<InstructorBankAccount> InstructorBankAccounts => Set<InstructorBankAccount>();
public DbSet<InstructorTaxProfile> InstructorTaxProfiles => Set<InstructorTaxProfile>();
public DbSet<InstructorSettings> InstructorSettings => Set<InstructorSettings>();
public DbSet<InstructorPreference> InstructorPreferences => Set<InstructorPreference>();
public DbSet<InstructorNotificationPreference> InstructorNotificationPreferences => Set<InstructorNotificationPreference>();
public DbSet<InstructorSocialLink> InstructorSocialLinks => Set<InstructorSocialLink>();
public DbSet<InstructorAvailability> InstructorAvailabilities => Set<InstructorAvailability>();
public DbSet<InstructorApproval> InstructorApprovals => Set<InstructorApproval>();
    public DbSet<InstructorWallet> InstructorWallets => Set<InstructorWallet>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Student
        modelBuilder.ApplyConfiguration(
            new StudentProfileConfiguration());

        modelBuilder.ApplyConfiguration(
            new StudentAddressConfiguration());

        modelBuilder.ApplyConfiguration(
            new StudentSubscriptionConfiguration());

        modelBuilder.ApplyConfiguration(
            new StudentPreferenceConfiguration());

        modelBuilder.ApplyConfiguration(
           new StudentEmergencyContactConfiguration());

        modelBuilder.ApplyConfiguration(
            new StudentDocumentConfiguration());

        modelBuilder.ApplyConfiguration(
           new StudentWishlistConfiguration());

        modelBuilder.ApplyConfiguration(
            new StudentNotificationPreferenceConfiguration());

        modelBuilder.ApplyConfiguration(
            new StudentSettingsConfiguration());

// Instuctor

modelBuilder.ApplyConfiguration(new InstructorProfileConfiguration());
modelBuilder.ApplyConfiguration(new InstructorQualificationConfiguration());
modelBuilder.ApplyConfiguration(new InstructorExperienceConfiguration());
modelBuilder.ApplyConfiguration(new InstructorSkillConfiguration());
modelBuilder.ApplyConfiguration(new InstructorCertificationConfiguration());
modelBuilder.ApplyConfiguration(new InstructorAddressConfiguration());
modelBuilder.ApplyConfiguration(new InstructorDocumentConfiguration());
modelBuilder.ApplyConfiguration(new InstructorVerificationConfiguration());
modelBuilder.ApplyConfiguration(new InstructorSubscriptionConfiguration());
modelBuilder.ApplyConfiguration(new InstructorBankAccountConfiguration());
modelBuilder.ApplyConfiguration(new InstructorTaxProfileConfiguration());
modelBuilder.ApplyConfiguration(new InstructorSettingsConfiguration());
modelBuilder.ApplyConfiguration(new InstructorPreferenceConfiguration());
modelBuilder.ApplyConfiguration(new InstructorNotificationPreferenceConfiguration());
modelBuilder.ApplyConfiguration(new InstructorSocialLinkConfiguration());
modelBuilder.ApplyConfiguration(new InstructorAvailabilityConfiguration());
modelBuilder.ApplyConfiguration(new InstructorApprovalConfiguration());
modelBuilder.ApplyConfiguration(new InstructorWalletConfiguration());

    }
}

using LMS.Domain.Entities.Students;
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
    }
}
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

    // ============================
    // Students
    // ============================

    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(
            new StudentProfileConfiguration());
    }
}
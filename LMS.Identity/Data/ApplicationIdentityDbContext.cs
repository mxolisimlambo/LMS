using LMS.Identity.Models;
using LMS.Identity.Permissions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace LMS.Identity.Data;

public class ApplicationIdentityDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationIdentityDbContext(
        DbContextOptions<ApplicationIdentityDbContext> options)
        : base(options)
    {
    }
    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Permission>(entity =>
{
    entity.HasKey(x => x.Id);

    entity.Property(x => x.Name)
        .HasMaxLength(200)
        .IsRequired();

    entity.HasIndex(x => x.Name)
        .IsUnique();

    entity.Property(x => x.DisplayName)
        .HasMaxLength(200)
        .IsRequired();

    entity.Property(x => x.Module)
        .HasMaxLength(100)
        .IsRequired();

    entity.Property(x => x.Description)
        .HasMaxLength(500);
});

        builder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Role)
                  .WithMany(r => r.RolePermissions)
                  .HasForeignKey(x => x.RoleId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.Permission)
                .WithMany(p => p.RolePermissions)
                  .HasForeignKey(x => x.PermissionId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(x => new
            {
                x.RoleId,
                x.PermissionId
            }).IsUnique();
        });
        base.OnModelCreating(builder);
    }
}

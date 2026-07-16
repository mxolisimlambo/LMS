using LMS.Identity.Models;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
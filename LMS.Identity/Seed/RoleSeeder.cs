using LMS.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace LMS.Identity.Seed;

public static class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<ApplicationRole> roleManager)
    {
        var roles = new List<ApplicationRole>
        {
            new()
            {
                Name = "SuperAdmin",
                Description = "System Super Administrator"
            },

            new()
            {
                Name = "Admin",
                Description = "System Administrator"
            },

            new()
            {
                Name = "Instructor",
                Description = "Course Instructor"
            },

            new()
            {
                Name = "Student",
                Description = "Student"
            },

            new()
            {
                Name = "Finance",
                Description = "Finance Department"
            },

            new()
            {
                Name = "Support",
                Description = "Customer Support"
            }
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name!))
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}

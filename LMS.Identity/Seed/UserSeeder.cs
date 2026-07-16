using LMS.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace LMS.Identity.Seed;

public static class UserSeeder
{
    public static async Task SeedSuperAdminAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        string email = "admin@lms.com";

        if (await userManager.FindByEmailAsync(email) != null)
            return;

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FirstName = "System",
            LastName = "Administrator",
            EmailConfirmed = true,
            IsActive = true
        };

        var result = await userManager.CreateAsync(user, "Admin@12345");

        if (result.Succeeded)
        {
            if (!await roleManager.RoleExistsAsync("SuperAdmin"))
            {
                await roleManager.CreateAsync(new ApplicationRole
                {
                    Name = "SuperAdmin",
                    Description = "System Super Administrator"
                });
            }

            await userManager.AddToRoleAsync(user, "SuperAdmin");
        }
    }
}
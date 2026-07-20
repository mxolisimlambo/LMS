using LMS.Identity.Data;
using LMS.Identity.Models;
using LMS.Identity.Permissions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS.Identity.Roles;

public static class RolePermissionSeeder
{
    public static async Task SeedAsync(
        ApplicationIdentityDbContext context,
        RoleManager<ApplicationRole> roleManager)
    {
        await AssignAllPermissions(
            "SuperAdmin",
            context,
            roleManager);

        await AssignAdminPermissions(
            context,
            roleManager);

        await AssignInstructorPermissions(
            context,
            roleManager);

        await AssignStudentPermissions(
            context,
            roleManager);
    }

    private static async Task AssignAllPermissions(
        string roleName,
        ApplicationIdentityDbContext context,
        RoleManager<ApplicationRole> roleManager)
    {
        var role = await roleManager.FindByNameAsync(roleName);

        if (role == null)
            return;

        var permissions = await context.Permissions.ToListAsync();

        foreach (var permission in permissions)
        {
            bool exists = await context.RolePermissions.AnyAsync(x =>
                x.RoleId == role.Id &&
                x.PermissionId == permission.Id);

            if (!exists)
            {
                context.RolePermissions.Add(new RolePermission
                {
                    RoleId = role.Id,
                    PermissionId = permission.Id
                });
            }
        }

        await context.SaveChangesAsync();
    }

    private static async Task AssignAdminPermissions(
        ApplicationIdentityDbContext context,
        RoleManager<ApplicationRole> roleManager)
    {
        await AssignAllPermissions(
            "Admin",
            context,
            roleManager);
    }

    private static async Task AssignInstructorPermissions(
        ApplicationIdentityDbContext context,
        RoleManager<ApplicationRole> roleManager)
    {
        var role = await roleManager.FindByNameAsync("Instructor");

        if (role == null)
            return;

        var allowedModules = new[]
        {
            "Dashboard",
            "Courses",
            "Lessons",
            "Assignments",
            "Quizzes",
            "Certificates",
            "Students"
        };

        var permissions = await context.Permissions
            .Where(x => allowedModules.Contains(x.Module))
            .ToListAsync();

        foreach (var permission in permissions)
        {
            bool exists = await context.RolePermissions.AnyAsync(x =>
                x.RoleId == role.Id &&
                x.PermissionId == permission.Id);

            if (!exists)
            {
                context.RolePermissions.Add(new RolePermission
                {
                    RoleId = role.Id,
                    PermissionId = permission.Id
                });
            }
        }

        await context.SaveChangesAsync();
    }

    private static async Task AssignStudentPermissions(
        ApplicationIdentityDbContext context,
        RoleManager<ApplicationRole> roleManager)
    {
        var role = await roleManager.FindByNameAsync("Student");

        if (role == null)
            return;

        var permissions = await context.Permissions
            .Where(x =>
                x.Name == PermissionConstants.Dashboard.View ||
                x.Name == PermissionConstants.Courses.View ||
                x.Name == PermissionConstants.Lessons.View ||
                x.Name == PermissionConstants.Assignments.View ||
                x.Name == PermissionConstants.Quizzes.View ||
                x.Name == PermissionConstants.Certificates.Download)
            .ToListAsync();

        foreach (var permission in permissions)
        {
            bool exists = await context.RolePermissions.AnyAsync(x =>
                x.RoleId == role.Id &&
                x.PermissionId == permission.Id);

            if (!exists)
            {
                context.RolePermissions.Add(new RolePermission
                {
                    RoleId = role.Id,
                    PermissionId = permission.Id
                });
            }
        }

        await context.SaveChangesAsync();
    }
}

using LMS.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Identity.Permissions;

public static class PermissionSeeder
{
    public static async Task SeedAsync(
        ApplicationIdentityDbContext context)
    {
        if (await context.Permissions.AnyAsync())
            return;

        var permissions = new List<Permission>
        {
            // Dashboard
            Create("Dashboard.View","View Dashboard","Dashboard"),

            // Users
            Create("Users.View","View Users","Users"),
            Create("Users.Create","Create Users","Users"),
            Create("Users.Update","Update Users","Users"),
            Create("Users.Delete","Delete Users","Users"),

            // Roles
            Create("Roles.View","View Roles","Roles"),
            Create("Roles.Create","Create Roles","Roles"),
            Create("Roles.Update","Update Roles","Roles"),
            Create("Roles.Delete","Delete Roles","Roles"),
            Create("Roles.Assign","Assign Roles","Roles"),

            // Permissions
            Create("Permissions.View","View Permissions","Permissions"),
            Create("Permissions.Assign","Assign Permissions","Permissions"),

            // Students
            Create("Students.View","View Students","Students"),
            Create("Students.Create","Create Students","Students"),
            Create("Students.Update","Update Students","Students"),
            Create("Students.Delete","Delete Students","Students"),

            // Instructors
            Create("Instructors.View","View Instructors","Instructors"),
            Create("Instructors.Create","Create Instructors","Instructors"),
            Create("Instructors.Update","Update Instructors","Instructors"),
            Create("Instructors.Delete","Delete Instructors","Instructors"),

            // Courses
            Create("Courses.View","View Courses","Courses"),
            Create("Courses.Create","Create Courses","Courses"),
            Create("Courses.Update","Update Courses","Courses"),
            Create("Courses.Delete","Delete Courses","Courses"),
            Create("Courses.Publish","Publish Courses","Courses"),

            // Lessons
            Create("Lessons.View","View Lessons","Lessons"),
            Create("Lessons.Create","Create Lessons","Lessons"),
            Create("Lessons.Update","Update Lessons","Lessons"),
            Create("Lessons.Delete","Delete Lessons","Lessons"),

            // Assignments
            Create("Assignments.View","View Assignments","Assignments"),
            Create("Assignments.Create","Create Assignments","Assignments"),
            Create("Assignments.Grade","Grade Assignments","Assignments"),

            // Quizzes
            Create("Quizzes.View","View Quizzes","Quizzes"),
            Create("Quizzes.Create","Create Quizzes","Quizzes"),
            Create("Quizzes.Grade","Grade Quizzes","Quizzes"),

            // Enrollments
            Create("Enrollments.View","View Enrollments","Enrollments"),
            Create("Enrollments.Create","Create Enrollments","Enrollments"),
            Create("Enrollments.Cancel","Cancel Enrollments","Enrollments"),

            // Payments
            Create("Payments.View","View Payments","Payments"),
            Create("Payments.Create","Create Payments","Payments"),
            Create("Payments.Approve","Approve Payments","Payments"),
            Create("Payments.Refund","Refund Payments","Payments"),

            // Certificates
            Create("Certificates.View","View Certificates","Certificates"),
            Create("Certificates.Issue","Issue Certificates","Certificates"),
            Create("Certificates.Download","Download Certificates","Certificates"),

            // Reports
            Create("Reports.View","View Reports","Reports"),
            Create("Reports.Export","Export Reports","Reports"),

            // CMS
            Create("CMS.View","View CMS","CMS"),
            Create("CMS.Update","Update CMS","CMS"),

            // Settings
            Create("Settings.View","View Settings","Settings"),
            Create("Settings.Update","Update Settings","Settings"),

            // Audit Logs
            Create("AuditLogs.View","View Audit Logs","AuditLogs")
        };

        await context.Permissions.AddRangeAsync(permissions);

        await context.SaveChangesAsync();
    }

    private static Permission Create(
        string name,
        string displayName,
        string module)
    {
        return new Permission
        {
            Name = name,
            DisplayName = displayName,
            Description = displayName,
            Module = module,
            IsActive = true
        };
    }
}

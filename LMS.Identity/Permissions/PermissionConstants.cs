namespace LMS.Identity.Permissions;

public static class PermissionConstants
{
    public static class Dashboard
    {
        public const string View = "Dashboard.View";
    }

    public static class Users
    {
        public const string View = "Users.View";
        public const string Create = "Users.Create";
        public const string Update = "Users.Update";
        public const string Delete = "Users.Delete";
    }

    public static class Roles
    {
        public const string View = "Roles.View";
        public const string Create = "Roles.Create";
        public const string Update = "Roles.Update";
        public const string Delete = "Roles.Delete";
        public const string Assign = "Roles.Assign";
    }

    public static class Permissions
    {
        public const string View = "Permissions.View";
        public const string Assign = "Permissions.Assign";
    }

    public static class Students
    {
        public const string View = "Students.View";
        public const string Create = "Students.Create";
        public const string Update = "Students.Update";
        public const string Delete = "Students.Delete";
    }

    public static class Instructors
    {
        public const string View = "Instructors.View";
        public const string Create = "Instructors.Create";
        public const string Update = "Instructors.Update";
        public const string Delete = "Instructors.Delete";
    }

    public static class Courses
    {
        public const string View = "Courses.View";
        public const string Create = "Courses.Create";
        public const string Update = "Courses.Update";
        public const string Delete = "Courses.Delete";
        public const string Publish = "Courses.Publish";
    }

    public static class Lessons
    {
        public const string View = "Lessons.View";
        public const string Create = "Lessons.Create";
        public const string Update = "Lessons.Update";
        public const string Delete = "Lessons.Delete";
    }

    public static class Assignments
    {
        public const string View = "Assignments.View";
        public const string Create = "Assignments.Create";
        public const string Grade = "Assignments.Grade";
    }

    public static class Quizzes
    {
        public const string View = "Quizzes.View";
        public const string Create = "Quizzes.Create";
        public const string Grade = "Quizzes.Grade";
    }

    public static class Enrollments
    {
        public const string View = "Enrollments.View";
        public const string Create = "Enrollments.Create";
        public const string Cancel = "Enrollments.Cancel";
    }

    public static class Payments
    {
        public const string View = "Payments.View";
        public const string Create = "Payments.Create";
        public const string Approve = "Payments.Approve";
        public const string Refund = "Payments.Refund";
    }

    public static class Certificates
    {
        public const string View = "Certificates.View";
        public const string Issue = "Certificates.Issue";
        public const string Download = "Certificates.Download";
    }

    public static class Reports
    {
        public const string View = "Reports.View";
        public const string Export = "Reports.Export";
    }

    public static class CMS
    {
        public const string View = "CMS.View";
        public const string Update = "CMS.Update";
    }

    public static class Settings
    {
        public const string View = "Settings.View";
        public const string Update = "Settings.Update";
    }

    public static class AuditLogs
    {
        public const string View = "AuditLogs.View";
    }
}
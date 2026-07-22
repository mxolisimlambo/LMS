using LMS.Domain.Entities.Courses.Catalog;
using LMS.Domain.Entities.Students;

namespace LMS.Domain.Entities.Courses.Catalog;

public class CourseView
{
    public long CourseViewId { get; set; }

    public long CourseId { get; set; }

    public long? StudentProfileId { get; set; }

    public string? IpAddress { get; set; }

    public string? DeviceType { get; set; }

    public string? Browser { get; set; }

    public string? OperatingSystem { get; set; }

    public DateTime ViewedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Properties

    public Course? Course { get; set; }

    public StudentProfile? StudentProfile { get; set; }
}
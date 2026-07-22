using LMS.Domain.Entities.Courses.Catalog;
using LMS.Domain.Entities.Students;

namespace LMS.Domain.Entities.Courses.Catalog;

public class CourseWishlist
{
    public long CourseWishlistId { get; set; }

    public long CourseId { get; set; }

    public long StudentProfileId { get; set; }

    public DateTime AddedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Properties

    public Course? Course { get; set; }

    public StudentProfile? StudentProfile { get; set; }
}
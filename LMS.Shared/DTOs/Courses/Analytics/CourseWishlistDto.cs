namespace LMS.Shared.DTOs.Courses.Analytics;

public class CourseWishlistDto
{
    public long CourseWishlistId { get; set; }

    public long CourseId { get; set; }

    public long StudentProfileId { get; set; }

    public DateTime AddedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

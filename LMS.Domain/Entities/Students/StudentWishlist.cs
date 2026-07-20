namespace LMS.Domain.Entities.Students;

public class StudentWishlist
{
    public long StudentWishlistId { get; set; }

    public long StudentProfileId { get; set; }

    public long CourseId { get; set; }

    public DateTime AddedDate { get; set; }

    public bool IsDeleted { get; set; }
}
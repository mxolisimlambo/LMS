namespace LMS.Shared.DTOs.Courses.Analytics;

public class CourseViewDto
{
    public long CourseViewId { get; set; }

    public long CourseId { get; set; }

    public long StudentProfileId { get; set; }

    public DateTime ViewedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

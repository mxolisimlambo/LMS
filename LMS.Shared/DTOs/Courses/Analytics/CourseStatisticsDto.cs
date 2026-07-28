namespace LMS.Shared.DTOs.Courses.Analytics;

public class CourseStatisticsDto
{
    public long CourseStatisticsId { get; set; }

    public long CourseId { get; set; }

    public int TotalViews { get; set; }

    public int TotalEnrollments { get; set; }

    public int TotalCompletions { get; set; }

    public decimal AverageRating { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

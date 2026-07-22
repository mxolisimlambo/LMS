using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Analytics;

public class CourseStatistics
{
    public long CourseStatisticsId { get; set; }

    public long CourseId { get; set; }

    public int TotalViews { get; set; }

    public int TotalEnrollments { get; set; }

    public int TotalCompletions { get; set; }

    public int TotalReviews { get; set; }

    public decimal AverageRating { get; set; }

    public int TotalWishlist { get; set; }

    public decimal TotalRevenue { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

    public Course? Course { get; set; }
}
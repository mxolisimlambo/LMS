using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Publishing;

public class CourseVisibility
{
    public long CourseVisibilityId { get; set; }

    public long CourseId { get; set; }

    public bool IsPublic { get; set; }

    public bool IsPrivate { get; set; }

    public bool IsUnlisted { get; set; }

    public bool FeaturedOnHomepage { get; set; }

    public bool AllowSearchEngineIndexing { get; set; }

    public bool VisibleInMarketplace { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

    public Course? Course { get; set; }
}
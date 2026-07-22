using LMS.Domain.Entities.Courses.Catalog;

namespace LMS.Domain.Entities.Courses.Information;

public class CourseOutcome
{
    public long CourseOutcomeId { get; set; }

    public long CourseId { get; set; }

    public string Outcome { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property

    public Course? Course { get; set; }
}
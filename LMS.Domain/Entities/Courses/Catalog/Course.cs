using LMS.Domain.Entities.Instructors;
using LMS.Domain.Entities.Courses.Information;
using LMS.Domain.Entities.Courses.Commerce;
using LMS.Domain.Entities.Courses.Content;
using LMS.Domain.Entities.Courses.Analytics;
using LMS.Domain.Entities.Courses.Publishing;
using LMS.Domain.Entities.Courses.Reviews;

namespace LMS.Domain.Entities.Courses.Catalog;

public class Course
{
    public long CourseId { get; set; }

    public long InstructorProfileId { get; set; }

    public long CourseCategoryId { get; set; }

    public long CourseSubCategoryId { get; set; }

    public long CourseLevelId { get; set; }

    public long CourseLanguageId { get; set; }

    public long CourseStatusId { get; set; }

    public string CourseCode { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Subtitle { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Thumbnail { get; set; } = string.Empty;

    public string PreviewVideo { get; set; } = string.Empty;

    public decimal DurationHours { get; set; }

    public decimal EstimatedStudyHours { get; set; }

    public int MaximumStudents { get; set; }

    public int MinimumStudents { get; set; }

    public bool IsFeatured { get; set; }

    public bool IsPremium { get; set; }

    public bool IsPublished { get; set; }

    public DateTime? PublishedDate { get; set; }

    public string? PublishedBy { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
    public InstructorProfile? InstructorProfile { get; set; }

    public CourseCategory? CourseCategory { get; set; }

    public CourseSubCategory? CourseSubCategory { get; set; }

    public CourseLevel? CourseLevel { get; set; }

    public CourseLanguage? CourseLanguage { get; set; }

    public CourseStatus? CourseStatus { get; set; }
    public CoursePrice? CoursePrice { get; set; }

    public CoursePublishing? CoursePublishing { get; set; }

    public CourseVisibility? CourseVisibility { get; set; }
    public CourseStatistics? CourseStatistics { get; set; }
    public ICollection<CourseTag> CourseTags { get; set; }
        = new List<CourseTag>();

    public ICollection<CourseRequirement> CourseRequirements { get; set; }
    = new List<CourseRequirement>();

    public ICollection<CourseOutcome> CourseOutcomes { get; set; }
        = new List<CourseOutcome>();

    public ICollection<CourseTargetAudience> CourseTargetAudiences { get; set; }
        = new List<CourseTargetAudience>();

    public ICollection<CourseFAQ> CourseFAQs { get; set; }
        = new List<CourseFAQ>();



    public ICollection<CourseDiscount> CourseDiscounts { get; set; }
        = new List<CourseDiscount>();

    public ICollection<CourseCoupon> CourseCoupons { get; set; }
        = new List<CourseCoupon>();
    public CourseApproval? CourseApproval { get; set; }

    public ICollection<CourseAnnouncement> CourseAnnouncements { get; set; }
        = new List<CourseAnnouncement>();
    public ICollection<CourseReview> CourseReviews { get; set; }
    = new List<CourseReview>();

    public ICollection<CourseRating> CourseRatings { get; set; }
        = new List<CourseRating>();

    public ICollection<CourseView> CourseViews { get; set; }
        = new List<CourseView>();

    public ICollection<CourseWishlist> CourseWishlists { get; set; }
        = new List<CourseWishlist>();


}
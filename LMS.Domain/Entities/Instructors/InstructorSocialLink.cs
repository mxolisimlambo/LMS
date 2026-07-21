namespace LMS.Domain.Entities.Instructors;

public class InstructorSocialLink
{
    public long InstructorSocialLinkId { get; set; }

    public long InstructorProfileId { get; set; }

    public string Platform { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}
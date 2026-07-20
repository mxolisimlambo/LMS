namespace LMS.Shared.DTOs.Students;

public class StudentSummaryDto
{
    public long StudentProfileId { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string Occupation { get; set; } = string.Empty;

    public string? Company { get; set; }

    public bool IsPremium { get; set; }

    public bool IsDeleted { get; set; }
}
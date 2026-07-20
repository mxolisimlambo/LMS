namespace LMS.Shared.DTOs.Students;

public class StudentProfileDto
{
    public long StudentProfileId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string StudentNumber { get; set; } = string.Empty;

    public string Occupation { get; set; } = string.Empty;

    public string? Company { get; set; }

    public string? ProfilePhoto { get; set; }

    public bool IsPremium { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
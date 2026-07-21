using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Students;

public class UpdateStudentProfileDto
{
    [Required]
    public long StudentProfileId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Occupation { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Company { get; set; }

    [MaxLength(500)]
    public string? ProfilePhoto { get; set; }

    public bool IsPremium { get; set; }
}
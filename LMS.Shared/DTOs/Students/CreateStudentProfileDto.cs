using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Students;

public class CreateStudentProfileDto
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Occupation { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Company { get; set; }

    [MaxLength(500)]
    public string? ProfilePhoto { get; set; }

    public bool IsPremium { get; set; }
}
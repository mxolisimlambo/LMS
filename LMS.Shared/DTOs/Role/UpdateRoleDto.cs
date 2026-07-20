using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Roles;

public class UpdateRoleDto
{
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; }
}

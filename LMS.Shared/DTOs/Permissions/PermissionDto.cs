namespace LMS.Shared.DTOs.Permissions;

public class PermissionDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Module { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}

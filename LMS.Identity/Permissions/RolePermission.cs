using LMS.Identity.Models;

namespace LMS.Identity.Permissions;

public class RolePermission
{
    public int Id { get; set; }

    public string RoleId { get; set; } = string.Empty;

    public int PermissionId { get; set; }

    public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

    public virtual ApplicationRole? Role { get; set; }

    public virtual Permission? Permission { get; set; }
}

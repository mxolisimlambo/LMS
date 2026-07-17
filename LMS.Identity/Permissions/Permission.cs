namespace LMS.Identity.Permissions;

public class Permission
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Module { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public virtual ICollection<RolePermission> RolePermissions
{
    get;
    set;
} = new List<RolePermission>();
}
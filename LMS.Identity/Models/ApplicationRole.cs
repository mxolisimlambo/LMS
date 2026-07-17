using Microsoft.AspNetCore.Identity;

namespace LMS.Identity.Models;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
    
     public virtual ICollection<ApplicationUser> Users
    {
        get;
        set;
    } = new List<ApplicationUser>();


    public virtual ICollection<LMS.Identity.Permissions.RolePermission>
        RolePermissions
    {
        get;
        set;
    } = new List<LMS.Identity.Permissions.RolePermission>();
}
using Microsoft.AspNetCore.Identity;

namespace LMS.Identity.Models;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}
using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Auth;

public class LoginUserDto
{
    public string UserId { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public List<string> Roles { get; set; } = new();

    public List<string> Permissions { get; set; } = new();
}
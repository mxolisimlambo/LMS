
namespace LMS.Shared.DTOs.Auth;
public class JwtTokenDto
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime Expires { get; set; }

    public List<string> Permissions { get; set; } = new();
}
namespace LMS.Shared.DTOs.Auth;

public class LogoutRequestDto
{
    public string UserId { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;
}
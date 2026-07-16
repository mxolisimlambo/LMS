namespace LMS.Shared.DTOs.Auth;

public class ForgotPasswordResponseDto
{
    public bool EmailSent { get; set; }

    public string? ResetToken { get; set; }
}
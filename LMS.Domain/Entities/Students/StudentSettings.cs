namespace LMS.Domain.Entities.Students;

public class StudentSettings
{
    public long StudentSettingsId { get; set; }

    public long StudentProfileId { get; set; }
    public bool ProfileVisible { get; set; }

    public bool ShowEmail { get; set; }

    public bool ShowPhoneNumber { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public bool AllowPublicProfile { get; set; }

    public bool AllowDirectMessages { get; set; }

    public bool RememberLastLogin { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
    public StudentProfile? StudentProfile { get; set; }
}

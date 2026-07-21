namespace LMS.Domain.Entities.Instructors;

public class InstructorWallet
{
    public long InstructorWalletId { get; set; }

    public long InstructorProfileId { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }

    public decimal CurrentBalance { get; set; }

    public decimal PendingBalance { get; set; }

    public decimal TotalEarned { get; set; }

    public decimal TotalWithdrawn { get; set; }

    public DateTime LastPayoutDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
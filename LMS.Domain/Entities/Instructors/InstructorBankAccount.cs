namespace LMS.Domain.Entities.Instructors;

public class InstructorBankAccount
{
    public long InstructorBankAccountId { get; set; }

    public long InstructorProfileId { get; set; }

    public string BankName { get; set; } = string.Empty;

    public string AccountHolder { get; set; } = string.Empty;

    public string AccountNumber { get; set; } = string.Empty;

    public string BranchCode { get; set; } = string.Empty;

    public string? SwiftCode { get; set; }

    public bool IsPrimary { get; set; }

    public bool Verified { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}

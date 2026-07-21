namespace LMS.Domain.Entities.Instructors;

public class InstructorSubscription
{
    public long InstructorSubscriptionId { get; set; }

    public long InstructorProfileId { get; set; }

    public string SubscriptionType { get; set; } = string.Empty;

    public decimal MonthlyFee { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool AutoRenew { get; set; }

    public string Status { get; set; } = string.Empty;

    public InstructorProfile? InstructorProfile { get; set; }
}
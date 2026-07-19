namespace LMS.Domain.Entities.Students;

public class StudentSubscription
{
    public long StudentSubscriptionId { get; set; }

    public long StudentProfileId { get; set; }

    public int SubscriptionPlanId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool AutoRenew { get; set; }

    public bool IsActive { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public long? PaymentId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
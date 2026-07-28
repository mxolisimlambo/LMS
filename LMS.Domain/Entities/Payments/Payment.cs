using LMS.Domain.Entities.Students;
//using LMS.Domain.Entities.Shopping;

namespace LMS.Domain.Entities.Payments;

public class Payment
{
    public long PaymentId { get; set; }

    public long OrderId { get; set; }

    public long StudentProfileId { get; set; }

    public long PaymentMethodId { get; set; }

    public decimal Amount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public string PaymentReference { get; set; } = string.Empty;

    public string PaymentStatus { get; set; } = "Pending";

    public DateTime PaymentDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Properties

    // public Order? Order { get; set; }

    public StudentProfile? StudentProfile { get; set; }

    public PaymentMethod? PaymentMethod { get; set; }

    public Invoice? Invoice { get; set; }

    public ICollection<PaymentTransaction> PaymentTransactions
        = new List<PaymentTransaction>();

    public ICollection<Refund> Refunds
        = new List<Refund>();
}

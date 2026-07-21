using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Domain.Entities.Instructors;

public class InstructorProfile
{
    public long InstructorProfileId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string InstructorNumber { get; set; } = string.Empty;

    public string ProfessionalHeadline { get; set; } = string.Empty;

    public string Biography { get; set; } = string.Empty;

    public string? ProfilePhoto { get; set; }

    public string? BannerImage { get; set; }

    public string? Website { get; set; }

    public int YearsExperience { get; set; }

    public decimal AverageRating { get; set; }

    public int TotalReviews { get; set; }

    public int TotalStudents { get; set; }

    public int TotalCourses { get; set; }

    public decimal TotalSales { get; set; }

    public decimal WalletBalance { get; set; }

    public string ApprovalStatus { get; set; } = "Pending";

    public string VerificationStatus { get; set; } = "Not Submitted";

    public bool IsPremium { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    //==========================
    // One-to-One
    //==========================

    public InstructorSettings? InstructorSettings { get; set; }

    public InstructorPreference? InstructorPreference { get; set; }

    public InstructorNotificationPreference? InstructorNotificationPreference { get; set; }

    public InstructorSubscription? InstructorSubscription { get; set; }

    public InstructorVerification? InstructorVerification { get; set; }

    public InstructorTaxProfile? InstructorTaxProfile { get; set; }

    public InstructorAvailability? InstructorAvailability { get; set; }

public InstructorApproval? InstructorApproval { get; set; }

public InstructorWallet? InstructorWallet { get; set; }


    //==========================
    // One-to-Many
    //==========================

    public ICollection<InstructorQualification> InstructorQualifications { get; set; }
        = new List<InstructorQualification>();

    public ICollection<InstructorExperience> InstructorExperiences { get; set; }
        = new List<InstructorExperience>();

    public ICollection<InstructorSkill> InstructorSkills { get; set; }
        = new List<InstructorSkill>();

    public ICollection<InstructorCertification> InstructorCertifications { get; set; }
        = new List<InstructorCertification>();

    public ICollection<InstructorAddress> InstructorAddresses { get; set; }
        = new List<InstructorAddress>();

    public ICollection<InstructorDocument> InstructorDocuments { get; set; }
        = new List<InstructorDocument>();

    public ICollection<InstructorBankAccount> InstructorBankAccounts { get; set; }
        = new List<InstructorBankAccount>();

    public ICollection<InstructorSocialLink> InstructorSocialLinks { get; set; }
        = new List<InstructorSocialLink>();
}
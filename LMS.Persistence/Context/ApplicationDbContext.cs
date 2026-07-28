using LMS.Domain.Entities.Commerce.ShoppingCard;
using LMS.Domain.Entities.Courses.Analytics;
using LMS.Domain.Entities.Courses.Catalog;
using LMS.Domain.Entities.Courses.Commerce;
using LMS.Domain.Entities.Courses.Content;
using LMS.Domain.Entities.Courses.Information;
using LMS.Domain.Entities.Courses.Publishing;
using LMS.Domain.Entities.Courses.Reviews;
using LMS.Domain.Entities.Instructors;
using LMS.Domain.Entities.Payments;
using LMS.Domain.Entities.Students;
using LMS.Domain.Entities.Commerce.Orders;

using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // ==========================================
    // Student Module
    // ==========================================

    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
    public DbSet<StudentAddress> StudentAddresses => Set<StudentAddress>();
    public DbSet<StudentSubscription> StudentSubscriptions => Set<StudentSubscription>();
    public DbSet<StudentPreference> StudentPreferences => Set<StudentPreference>();
    public DbSet<StudentEmergencyContact> StudentEmergencyContacts => Set<StudentEmergencyContact>();
    public DbSet<StudentWishlist> StudentWishlists => Set<StudentWishlist>();
    public DbSet<StudentDocument> StudentDocuments => Set<StudentDocument>();
    public DbSet<StudentNotificationPreference> StudentNotificationPreferences => Set<StudentNotificationPreference>();
    public DbSet<StudentSettings> StudentSettings => Set<StudentSettings>();

    // ==========================================
    // Instructor Module
    // ==========================================

    public DbSet<InstructorProfile> InstructorProfiles => Set<InstructorProfile>();
    public DbSet<InstructorQualification> InstructorQualifications => Set<InstructorQualification>();
    public DbSet<InstructorExperience> InstructorExperiences => Set<InstructorExperience>();
    public DbSet<InstructorSkill> InstructorSkills => Set<InstructorSkill>();
    public DbSet<InstructorCertification> InstructorCertifications => Set<InstructorCertification>();
    public DbSet<InstructorAddress> InstructorAddresses => Set<InstructorAddress>();
    public DbSet<InstructorDocument> InstructorDocuments => Set<InstructorDocument>();
    public DbSet<InstructorVerification> InstructorVerifications => Set<InstructorVerification>();
    public DbSet<InstructorSubscription> InstructorSubscriptions => Set<InstructorSubscription>();
    public DbSet<InstructorBankAccount> InstructorBankAccounts => Set<InstructorBankAccount>();
    public DbSet<InstructorTaxProfile> InstructorTaxProfiles => Set<InstructorTaxProfile>();
    public DbSet<InstructorSettings> InstructorSettings => Set<InstructorSettings>();
    public DbSet<InstructorPreference> InstructorPreferences => Set<InstructorPreference>();
    public DbSet<InstructorNotificationPreference> InstructorNotificationPreferences => Set<InstructorNotificationPreference>();
    public DbSet<InstructorSocialLink> InstructorSocialLinks => Set<InstructorSocialLink>();
    public DbSet<InstructorAvailability> InstructorAvailabilities => Set<InstructorAvailability>();
    public DbSet<InstructorApproval> InstructorApprovals => Set<InstructorApproval>();
    public DbSet<InstructorWallet> InstructorWallets => Set<InstructorWallet>();

    // ==========================================
    // Course Module - Catalog
    // ==========================================

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseCategory> CourseCategories => Set<CourseCategory>();
    public DbSet<CourseSubCategory> CourseSubCategories => Set<CourseSubCategory>();
    public DbSet<CourseLevel> CourseLevels => Set<CourseLevel>();
    public DbSet<CourseLanguage> CourseLanguages => Set<CourseLanguage>();
    public DbSet<CourseStatus> CourseStatuses => Set<CourseStatus>();
    public DbSet<CourseTag> CourseTags => Set<CourseTag>();

    // ==========================================
    // Course Module - Information
    // ==========================================

    public DbSet<CourseRequirement> CourseRequirements => Set<CourseRequirement>();
    public DbSet<CourseOutcome> CourseOutcomes => Set<CourseOutcome>();
    public DbSet<CourseTargetAudience> CourseTargetAudiences => Set<CourseTargetAudience>();
    public DbSet<CourseFAQ> CourseFAQs => Set<CourseFAQ>();

    // ==========================================
    // Course Module - Commerce
    // ==========================================

    public DbSet<CoursePrice> CoursePrices => Set<CoursePrice>();
    public DbSet<CourseDiscount> CourseDiscounts => Set<CourseDiscount>();
    public DbSet<CourseCoupon> CourseCoupons => Set<CourseCoupon>();

    // ==========================================
    // Course Module - Content
    // ==========================================

    public DbSet<CourseModule> CourseModules => Set<CourseModule>();
    public DbSet<CourseLesson> CourseLessons => Set<CourseLesson>();
    public DbSet<CourseVideo> CourseVideos => Set<CourseVideo>();
    public DbSet<CourseDocument> CourseDocuments => Set<CourseDocument>();
    public DbSet<CourseAttachment> CourseAttachments => Set<CourseAttachment>();
    public DbSet<CourseResource> CourseResources => Set<CourseResource>();

    // ==========================================
    // Course Module - Publishing
    // ==========================================

    public DbSet<CoursePublishing> CoursePublishings => Set<CoursePublishing>();
    public DbSet<CourseApproval> CourseApprovals => Set<CourseApproval>();
    public DbSet<CourseAnnouncement> CourseAnnouncements => Set<CourseAnnouncement>();
    public DbSet<CourseVisibility> CourseVisibilities => Set<CourseVisibility>();

    // ==========================================
    // Course Module - Analytics
    // ==========================================

    public DbSet<CourseStatistics> CourseStatistics => Set<CourseStatistics>();
    public DbSet<CourseView> CourseViews => Set<CourseView>();
    public DbSet<CourseWishlist> CourseWishlists => Set<CourseWishlist>();

    // ==========================================
    // Course Module - Reviews
    // ==========================================

    public DbSet<CourseReview> CourseReviews => Set<CourseReview>();
    public DbSet<CourseRating> CourseRatings => Set<CourseRating>();

    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Refund> Refunds { get; set; }

    // ======================================================
    // SHOPPING CART
    // ======================================================

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    // ======================================================
// ORDERS
// ======================================================

public DbSet<Order> Orders { get; set; }
public DbSet<OrderItem> OrderItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }
}

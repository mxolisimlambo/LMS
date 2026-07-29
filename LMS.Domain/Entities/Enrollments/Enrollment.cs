using LMS.Domain.Entities.Commerce.Orders;
using LMS.Domain.Entities.Courses.Catalog;
using LMS.Domain.Entities.Students;

namespace LMS.Domain.Entities.Enrollments;

public class Enrollment
{
// ======================================================
// PRIMARY KEY
// ======================================================

public long EnrollmentId { get; set; }

// ======================================================
// FOREIGN KEYS
// ======================================================

public long StudentProfileId { get; set; }

public long CourseId { get; set; }

public long OrderItemId { get; set; }

// ======================================================
// ENROLMENT STATUS
// ======================================================

public string EnrollmentStatus { get; set; }
    = "Active";

// ======================================================
// ENROLMENT AND COURSE ACCESS DATES
// ======================================================

public DateTime EnrolledDate { get; set; }

public DateTime? AccessStartDate { get; set; }

public DateTime? AccessEndDate { get; set; }

// ======================================================
// STUDENT LEARNING PROGRESS
// ======================================================

public decimal ProgressPercentage { get; set; }

public DateTime? LastAccessedDate { get; set; }

public DateTime? CompletedDate { get; set; }

// ======================================================
// CERTIFICATE
// ======================================================

public bool IsCertificateEligible { get; set; }

// ======================================================
// AUDIT AND SOFT DELETE
// ======================================================

public DateTime? UpdatedDate { get; set; }

public bool IsDeleted { get; set; }

// ======================================================
// NAVIGATION PROPERTIES
// ======================================================

public StudentProfile? StudentProfile { get; set; }

public Course? Course { get; set; }

public OrderItem? OrderItem { get; set; }

}

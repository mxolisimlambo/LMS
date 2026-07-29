namespace LMS.Shared.DTOs.Enrollments.Enrollment;

public class EnrollmentDto
{
// ======================================================
// ENROLLMENT
// ======================================================

public long EnrollmentId { get; set; }

// ======================================================
// STUDENT AND COURSE
// ======================================================

public long StudentProfileId { get; set; }

public long CourseId { get; set; }

public long OrderItemId { get; set; }

// ======================================================
// ENROLLMENT STATUS
// ======================================================

public string EnrollmentStatus { get; set; }
    = string.Empty;

// ======================================================
// COURSE ACCESS
// ======================================================

public DateTime EnrolledDate { get; set; }

public DateTime? AccessStartDate { get; set; }

public DateTime? AccessEndDate { get; set; }

// ======================================================
// LEARNING PROGRESS
// ======================================================

public decimal ProgressPercentage { get; set; }

public DateTime? LastAccessedDate { get; set; }

public DateTime? CompletedDate { get; set; }

// ======================================================
// CERTIFICATE
// ======================================================

public bool IsCertificateEligible { get; set; }

// ======================================================
// AUDIT
// ======================================================

public DateTime? UpdatedDate { get; set; }

public bool IsDeleted { get; set; }

}

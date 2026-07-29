namespace LMS.Shared.DTOs.Enrollments.Enrollment;

public class EnrollmentSummaryDto
{
// ======================================================
// ENROLLMENT
// ======================================================

public long EnrollmentId { get; set; }

// ======================================================
// COURSE
// ======================================================

public long CourseId { get; set; }

public string CourseTitle { get; set; }
    = string.Empty;

// ======================================================
// STATUS AND PROGRESS
// ======================================================

public string EnrollmentStatus { get; set; }
    = string.Empty;

public decimal ProgressPercentage { get; set; }

// ======================================================
// DATES
// ======================================================

public DateTime EnrolledDate { get; set; }

public DateTime? LastAccessedDate { get; set; }

public DateTime? CompletedDate { get; set; }

}

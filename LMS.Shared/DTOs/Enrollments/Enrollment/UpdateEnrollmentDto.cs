using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Enrollments.Enrollment;

public class UpdateEnrollmentDto
{
// ======================================================
// ENROLLMENT
// ======================================================

[Required]
[Range(1, long.MaxValue)]
public long EnrollmentId { get; set; }

// ======================================================
// ENROLLMENT STATUS
// ======================================================

[Required]
[StringLength(50)]
public string EnrollmentStatus { get; set; }
    = string.Empty;

// ======================================================
// COURSE ACCESS
// ======================================================

public DateTime? AccessStartDate { get; set; }

public DateTime? AccessEndDate { get; set; }

}

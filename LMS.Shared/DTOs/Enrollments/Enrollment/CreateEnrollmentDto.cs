using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Enrollments.Enrollment;

public class CreateEnrollmentDto
{
// ======================================================
// STUDENT PROFILE
// ======================================================

[Required]
[Range(1, long.MaxValue)]
public long StudentProfileId { get; set; }

// ======================================================
// COURSE
// ======================================================

[Required]
[Range(1, long.MaxValue)]
public long CourseId { get; set; }

// ======================================================
// PURCHASED ORDER ITEM
// ======================================================

[Required]
[Range(1, long.MaxValue)]
public long OrderItemId { get; set; }

// ======================================================
// COURSE ACCESS
// ======================================================

public DateTime? AccessStartDate { get; set; }

public DateTime? AccessEndDate { get; set; }

}

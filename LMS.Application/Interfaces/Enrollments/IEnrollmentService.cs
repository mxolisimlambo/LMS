using LMS.Shared.DTOs.Enrollments.Enrollment;

namespace LMS.Application.Interfaces.Enrollments;

public interface IEnrollmentService
{

// ======================================================
// CREATE ENROLLMENTS FROM ORDER
// ======================================================

Task CreateEnrollmentsAsync(
    long studentProfileId,
    long orderId);


// ======================================================
// UPDATE ENROLLMENT
// ======================================================

Task<bool> UpdateEnrollmentAsync(
    UpdateEnrollmentDto dto);

// ======================================================
// DELETE ENROLLMENT
// ======================================================

Task<bool> DeleteEnrollmentAsync(
    long enrollmentId);

// ======================================================
// GET ENROLLMENT
// ======================================================

Task<EnrollmentDto?> GetEnrollmentByIdAsync(
    long enrollmentId);

// ======================================================
// GET STUDENT ENROLLMENTS
// ======================================================

Task<IEnumerable<EnrollmentSummaryDto>>
    GetEnrollmentsByStudentAsync(
        long studentProfileId);

// ======================================================
// GET COURSE ENROLLMENTS
// ======================================================

Task<IEnumerable<EnrollmentSummaryDto>>
    GetEnrollmentsByCourseAsync(
        long courseId);

// ======================================================
// GET STUDENT ENROLLMENT FOR COURSE
// ======================================================

Task<EnrollmentDto?>
    GetStudentEnrollmentByCourseAsync(
        long studentProfileId,
        long courseId);

// ======================================================
// GET ENROLLMENTS BY STATUS
// ======================================================

Task<IEnumerable<EnrollmentSummaryDto>>
    GetEnrollmentsByStatusAsync(
        string enrollmentStatus);

// ======================================================
// ACTIVATE ENROLLMENT
// ======================================================

Task<bool> ActivateEnrollmentAsync(
    long enrollmentId);

// ======================================================
// COMPLETE ENROLLMENT
// ======================================================

Task<bool> CompleteEnrollmentAsync(
    long enrollmentId);

// ======================================================
// SUSPEND ENROLLMENT
// ======================================================

Task<bool> SuspendEnrollmentAsync(
    long enrollmentId);

// ======================================================
// CANCEL ENROLLMENT
// ======================================================

Task<bool> CancelEnrollmentAsync(
    long enrollmentId);

// ======================================================
// UPDATE LEARNING PROGRESS
// ======================================================

Task<bool> UpdateProgressAsync(
    long enrollmentId,
    decimal progressPercentage);

// ======================================================
// UPDATE LAST ACCESSED DATE
// ======================================================

Task<bool> UpdateLastAccessedAsync(
    long enrollmentId);

// ======================================================
// UPDATE CERTIFICATE ELIGIBILITY
// ======================================================

Task<bool> UpdateCertificateEligibilityAsync(
    long enrollmentId,
    bool isEligible);

// ======================================================
// CHECK ENROLLMENT EXISTS
// ======================================================

Task<bool> ExistsAsync(
    long enrollmentId);

}

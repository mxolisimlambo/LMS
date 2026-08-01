using LMS.Application.Interfaces.Enrollments;
using LMS.Domain.Entities.Enrollments;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Enrollments.Enrollment;
using LMS.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Enrollments;

public class EnrollmentService : IEnrollmentService
{
private readonly ApplicationDbContext _context;

public EnrollmentService(
    ApplicationDbContext context)
{
    _context = context;
}

public async Task CreateEnrollmentsAsync(
    long studentProfileId,
    long orderId)
{
    var order = await _context.Orders
        .Include(x => x.OrderItems)
        .FirstOrDefaultAsync(x =>
            x.OrderId == orderId &&
            !x.IsDeleted);

    if (order == null)
        return;

    foreach (var orderItem in order.OrderItems)
    {
        var enrollment = await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.StudentProfileId == studentProfileId &&
                x.CourseId == orderItem.CourseId);

        if (enrollment != null)
        {
            enrollment.OrderItemId =
                orderItem.OrderItemId;

            enrollment.EnrollmentStatus =
                "Active";

            enrollment.AccessStartDate =
                DateTime.UtcNow;

            enrollment.AccessEndDate =
                null;

            enrollment.IsDeleted =
                false;

            enrollment.UpdatedDate =
                DateTime.UtcNow;

            continue;
        }

        enrollment = new Enrollment
        {
            StudentProfileId =
                studentProfileId,

            CourseId =
                orderItem.CourseId,

            OrderItemId =
                orderItem.OrderItemId,

            EnrollmentStatus =
                "Active",

            EnrolledDate =
                DateTime.UtcNow,

            AccessStartDate =
                DateTime.UtcNow,

            AccessEndDate =
                null,

            ProgressPercentage =
                0m,

            LastAccessedDate =
                null,

            CompletedDate =
                null,

            IsCertificateEligible =
                false,

            UpdatedDate =
                null,

            IsDeleted =
                false
        };

        _context.Enrollments.Add(
            enrollment);
    }

    await _context.SaveChangesAsync();
}
// ======================================================
// UPDATE ENROLLMENT
// ======================================================

public async Task<bool> UpdateEnrollmentAsync(
    UpdateEnrollmentDto dto)
{
    var enrollment =
        await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.EnrollmentId ==
                dto.EnrollmentId &&
                !x.IsDeleted);

    if (enrollment == null)
        return false;

    if (string.IsNullOrWhiteSpace(
        dto.EnrollmentStatus))
    {
        return false;
    }

    enrollment.EnrollmentStatus =
        dto.EnrollmentStatus.Trim();

    enrollment.AccessStartDate =
        dto.AccessStartDate;

    enrollment.AccessEndDate =
        dto.AccessEndDate;

    enrollment.UpdatedDate =
        DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

// ======================================================
// SOFT DELETE ENROLLMENT
// ======================================================

public async Task<bool> DeleteEnrollmentAsync(
    long enrollmentId)
{
    var enrollment =
        await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.EnrollmentId ==
                enrollmentId &&
                !x.IsDeleted);

    if (enrollment == null)
        return false;

    enrollment.IsDeleted =
        true;

    enrollment.UpdatedDate =
        DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

// ======================================================
// GET ENROLLMENT BY ID
// ======================================================

public async Task<EnrollmentDto?>
    GetEnrollmentByIdAsync(
        long enrollmentId)
{
    return await _context.Enrollments
        .Where(x =>
            x.EnrollmentId ==
            enrollmentId &&
            !x.IsDeleted)
        .Select(x =>
            new EnrollmentDto
            {
                EnrollmentId =
                    x.EnrollmentId,

                StudentProfileId =
                    x.StudentProfileId,

                CourseId =
                    x.CourseId,

                OrderItemId =
                    x.OrderItemId,

                EnrollmentStatus =
                    x.EnrollmentStatus,

                EnrolledDate =
                    x.EnrolledDate,

                AccessStartDate =
                    x.AccessStartDate,

                AccessEndDate =
                    x.AccessEndDate,

                ProgressPercentage =
                    x.ProgressPercentage,

                LastAccessedDate =
                    x.LastAccessedDate,

                CompletedDate =
                    x.CompletedDate,

                IsCertificateEligible =
                    x.IsCertificateEligible,

                UpdatedDate =
                    x.UpdatedDate,

                IsDeleted =
                    x.IsDeleted
            })
        .FirstOrDefaultAsync();
}

// ======================================================
// GET ENROLLMENTS BY STUDENT
// ======================================================

public async Task<IEnumerable<
    EnrollmentSummaryDto>>
    GetEnrollmentsByStudentAsync(
        long studentProfileId)
{
    return await _context.Enrollments
        .Include(x => x.Course)
        .Where(x =>
            x.StudentProfileId ==
            studentProfileId &&
            !x.IsDeleted)
        .OrderByDescending(x =>
            x.EnrolledDate)
        .Select(x =>
            new EnrollmentSummaryDto
            {
                EnrollmentId =
                    x.EnrollmentId,

                CourseId =
                    x.CourseId,

                CourseTitle =
                    x.Course != null
                        ? x.Course.Title
                        : string.Empty,

                EnrollmentStatus =
                    x.EnrollmentStatus,

                ProgressPercentage =
                    x.ProgressPercentage,

                EnrolledDate =
                    x.EnrolledDate,

                LastAccessedDate =
                    x.LastAccessedDate,

                CompletedDate =
                    x.CompletedDate
            })
        .ToListAsync();
}

// ======================================================
// GET ENROLLMENTS BY COURSE
// ======================================================

public async Task<IEnumerable<
    EnrollmentSummaryDto>>
    GetEnrollmentsByCourseAsync(
        long courseId)
{
    return await _context.Enrollments
        .Include(x => x.Course)
        .Where(x =>
            x.CourseId ==
            courseId &&
            !x.IsDeleted)
        .OrderByDescending(x =>
            x.EnrolledDate)
        .Select(x =>
            new EnrollmentSummaryDto
            {
                EnrollmentId =
                    x.EnrollmentId,

                CourseId =
                    x.CourseId,

                CourseTitle =
                    x.Course != null
                        ? x.Course.Title
                        : string.Empty,

                EnrollmentStatus =
                    x.EnrollmentStatus,

                ProgressPercentage =
                    x.ProgressPercentage,

                EnrolledDate =
                    x.EnrolledDate,

                LastAccessedDate =
                    x.LastAccessedDate,

                CompletedDate =
                    x.CompletedDate
            })
        .ToListAsync();
}

// ======================================================
// GET STUDENT ENROLLMENT BY COURSE
// ======================================================

public async Task<EnrollmentDto?>
    GetStudentEnrollmentByCourseAsync(
        long studentProfileId,
        long courseId)
{
    return await _context.Enrollments
        .Where(x =>
            x.StudentProfileId ==
            studentProfileId &&
            x.CourseId ==
            courseId &&
            !x.IsDeleted)
        .Select(x =>
            new EnrollmentDto
            {
                EnrollmentId =
                    x.EnrollmentId,

                StudentProfileId =
                    x.StudentProfileId,

                CourseId =
                    x.CourseId,

                OrderItemId =
                    x.OrderItemId,

                EnrollmentStatus =
                    x.EnrollmentStatus,

                EnrolledDate =
                    x.EnrolledDate,

                AccessStartDate =
                    x.AccessStartDate,

                AccessEndDate =
                    x.AccessEndDate,

                ProgressPercentage =
                    x.ProgressPercentage,

                LastAccessedDate =
                    x.LastAccessedDate,

                CompletedDate =
                    x.CompletedDate,

                IsCertificateEligible =
                    x.IsCertificateEligible,

                UpdatedDate =
                    x.UpdatedDate,

                IsDeleted =
                    x.IsDeleted
            })
        .FirstOrDefaultAsync();
}

// ======================================================
// GET ENROLLMENTS BY STATUS
// ======================================================

public async Task<IEnumerable<
    EnrollmentSummaryDto>>
    GetEnrollmentsByStatusAsync(
        string enrollmentStatus)
{
    if (string.IsNullOrWhiteSpace(
        enrollmentStatus))
    {
        return new List<
            EnrollmentSummaryDto>();
    }

    var normalizedStatus =
        enrollmentStatus.Trim();

    return await _context.Enrollments
        .Include(x => x.Course)
        .Where(x =>
            x.EnrollmentStatus ==
            normalizedStatus &&
            !x.IsDeleted)
        .OrderByDescending(x =>
            x.EnrolledDate)
        .Select(x =>
            new EnrollmentSummaryDto
            {
                EnrollmentId =
                    x.EnrollmentId,

                CourseId =
                    x.CourseId,

                CourseTitle =
                    x.Course != null
                        ? x.Course.Title
                        : string.Empty,

                EnrollmentStatus =
                    x.EnrollmentStatus,

                ProgressPercentage =
                    x.ProgressPercentage,

                EnrolledDate =
                    x.EnrolledDate,

                LastAccessedDate =
                    x.LastAccessedDate,

                CompletedDate =
                    x.CompletedDate
            })
        .ToListAsync();
}

// ======================================================
// ACTIVATE ENROLLMENT
// ======================================================

public async Task<bool>
    ActivateEnrollmentAsync(
        long enrollmentId)
{
    var enrollment =
        await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.EnrollmentId ==
                enrollmentId &&
                !x.IsDeleted);

    if (enrollment == null)
        return false;

    enrollment.EnrollmentStatus =
        "Active";

    enrollment.AccessStartDate ??=
        DateTime.UtcNow;

    enrollment.UpdatedDate =
        DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

// ======================================================
// COMPLETE ENROLLMENT
// ======================================================

public async Task<bool>
    CompleteEnrollmentAsync(
        long enrollmentId)
{
    var enrollment =
        await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.EnrollmentId ==
                enrollmentId &&
                !x.IsDeleted);

    if (enrollment == null)
        return false;

    if (enrollment.EnrollmentStatus ==
        "Cancelled")
    {
        return false;
    }

    enrollment.ProgressPercentage =
        100m;

    enrollment.EnrollmentStatus =
        "Completed";

    enrollment.CompletedDate =
        DateTime.UtcNow;

    enrollment.UpdatedDate =
        DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

// ======================================================
// SUSPEND ENROLLMENT
// ======================================================

public async Task<bool>
    SuspendEnrollmentAsync(
        long enrollmentId)
{
    var enrollment =
        await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.EnrollmentId ==
                enrollmentId &&
                !x.IsDeleted);

    if (enrollment == null)
        return false;

    if (enrollment.EnrollmentStatus ==
        "Completed" ||
        enrollment.EnrollmentStatus ==
        "Cancelled")
    {
        return false;
    }

    enrollment.EnrollmentStatus =
        "Suspended";

    enrollment.UpdatedDate =
        DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

// ======================================================
// CANCEL ENROLLMENT
// ======================================================

public async Task<bool>
    CancelEnrollmentAsync(
        long enrollmentId)
{
    var enrollment =
        await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.EnrollmentId ==
                enrollmentId &&
                !x.IsDeleted);

    if (enrollment == null)
        return false;

    if (enrollment.EnrollmentStatus ==
        "Completed")
    {
        return false;
    }

    enrollment.EnrollmentStatus =
        "Cancelled";

    enrollment.UpdatedDate =
        DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

// ======================================================
// UPDATE LEARNING PROGRESS
// ======================================================

public async Task<bool>
    UpdateProgressAsync(
        long enrollmentId,
        decimal progressPercentage)
{
    if (progressPercentage < 0m ||
        progressPercentage > 100m)
    {
        return false;
    }

    var enrollment =
        await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.EnrollmentId ==
                enrollmentId &&
                !x.IsDeleted);

    if (enrollment == null)
        return false;

    if (enrollment.EnrollmentStatus !=
        "Active")
    {
        return false;
    }

    enrollment.ProgressPercentage =
        progressPercentage;

    enrollment.LastAccessedDate =
        DateTime.UtcNow;

    enrollment.UpdatedDate =
        DateTime.UtcNow;

    if (progressPercentage == 100m)
    {
        enrollment.EnrollmentStatus =
            "Completed";

        enrollment.CompletedDate =
            DateTime.UtcNow;
    }

    await _context.SaveChangesAsync();

    return true;
}

// ======================================================
// UPDATE LAST ACCESSED DATE
// ======================================================

public async Task<bool>
    UpdateLastAccessedAsync(
        long enrollmentId)
{
    var enrollment =
        await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.EnrollmentId ==
                enrollmentId &&
                !x.IsDeleted);

    if (enrollment == null)
        return false;

    if (enrollment.EnrollmentStatus !=
        "Active")
    {
        return false;
    }

    enrollment.LastAccessedDate =
        DateTime.UtcNow;

    enrollment.UpdatedDate =
        DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

// ======================================================
// UPDATE CERTIFICATE ELIGIBILITY
// ======================================================

public async Task<bool>
    UpdateCertificateEligibilityAsync(
        long enrollmentId,
        bool isEligible)
{
    var enrollment =
        await _context.Enrollments
            .FirstOrDefaultAsync(x =>
                x.EnrollmentId ==
                enrollmentId &&
                !x.IsDeleted);

    if (enrollment == null)
        return false;

    enrollment.IsCertificateEligible =
        isEligible;

    enrollment.UpdatedDate =
        DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

// ======================================================
// CHECK ENROLLMENT EXISTS
// ======================================================

public async Task<bool> ExistsAsync(
    long enrollmentId)
{
    return await _context.Enrollments
        .AnyAsync(x =>
            x.EnrollmentId ==
            enrollmentId &&
            !x.IsDeleted);
}

}

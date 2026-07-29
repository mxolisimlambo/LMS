using LMS.Application.Interfaces.Enrollments;
using LMS.Shared.DTOs.Enrollments.Enrollment;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Enrollments;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentController : ControllerBase
{
private readonly IEnrollmentService _enrollmentService;

public EnrollmentController(
    IEnrollmentService enrollmentService)
{
    _enrollmentService = enrollmentService;
}


// ======================================================
// UPDATE ENROLLMENT
// ======================================================

[HttpPut]
public async Task<IActionResult> UpdateEnrollment(
    [FromBody] UpdateEnrollmentDto dto)
{
    var result = await _enrollmentService
        .UpdateEnrollmentAsync(dto);

    if (!result)
    {
        return BadRequest(
            "The enrollment could not be updated.");
    }

    return Ok(new
    {
        Message =
            "The enrollment was updated successfully.",

        Success = true
    });
}

// ======================================================
// DELETE ENROLLMENT
// ======================================================

[HttpDelete("{enrollmentId:long}")]
public async Task<IActionResult> DeleteEnrollment(
    long enrollmentId)
{
    var result = await _enrollmentService
        .DeleteEnrollmentAsync(
            enrollmentId);

    if (!result)
    {
        return NotFound(
            $"Enrollment with ID {enrollmentId} " +
            "was not found.");
    }

    return Ok(new
    {
        Message =
            "The enrollment was deleted successfully.",

        Success = true
    });
}

// ======================================================
// GET ENROLLMENT BY ID
// ======================================================

[HttpGet("{enrollmentId:long}")]
public async Task<IActionResult> GetEnrollmentById(
    long enrollmentId)
{
    var result = await _enrollmentService
        .GetEnrollmentByIdAsync(
            enrollmentId);

    if (result == null)
    {
        return NotFound(
            $"Enrollment with ID {enrollmentId} " +
            "was not found.");
    }

    return Ok(result);
}

// ======================================================
// GET ENROLLMENTS BY STUDENT
// ======================================================

[HttpGet("student/{studentProfileId:long}")]
public async Task<IActionResult>
    GetEnrollmentsByStudent(
        long studentProfileId)
{
    var result = await _enrollmentService
        .GetEnrollmentsByStudentAsync(
            studentProfileId);

    return Ok(result);
}

// ======================================================
// GET ENROLLMENTS BY COURSE
// ======================================================

[HttpGet("course/{courseId:long}")]
public async Task<IActionResult>
    GetEnrollmentsByCourse(
        long courseId)
{
    var result = await _enrollmentService
        .GetEnrollmentsByCourseAsync(
            courseId);

    return Ok(result);
}

// ======================================================
// GET STUDENT ENROLLMENT BY COURSE
// ======================================================

[HttpGet(
    "student/{studentProfileId:long}" +
    "/course/{courseId:long}")]
public async Task<IActionResult>
    GetStudentEnrollmentByCourse(
        long studentProfileId,
        long courseId)
{
    var result = await _enrollmentService
        .GetStudentEnrollmentByCourseAsync(
            studentProfileId,
            courseId);

    if (result == null)
    {
        return NotFound(
            "The student enrollment for this " +
            "course was not found.");
    }

    return Ok(result);
}

// ======================================================
// GET ENROLLMENTS BY STATUS
// ======================================================

[HttpGet("status/{enrollmentStatus}")]
public async Task<IActionResult>
    GetEnrollmentsByStatus(
        string enrollmentStatus)
{
    var result = await _enrollmentService
        .GetEnrollmentsByStatusAsync(
            enrollmentStatus);

    return Ok(result);
}

// ======================================================
// ACTIVATE ENROLLMENT
// ======================================================

[HttpPut("activate/{enrollmentId:long}")]
public async Task<IActionResult>
    ActivateEnrollment(
        long enrollmentId)
{
    var result = await _enrollmentService
        .ActivateEnrollmentAsync(
            enrollmentId);

    if (!result)
    {
        return BadRequest(
            "The enrollment could not be activated.");
    }

    return Ok(new
    {
        Message =
            "The enrollment was activated successfully.",

        Success = true
    });
}

// ======================================================
// COMPLETE ENROLLMENT
// ======================================================

[HttpPut("complete/{enrollmentId:long}")]
public async Task<IActionResult>
    CompleteEnrollment(
        long enrollmentId)
{
    var result = await _enrollmentService
        .CompleteEnrollmentAsync(
            enrollmentId);

    if (!result)
    {
        return BadRequest(
            "The enrollment could not be completed.");
    }

    return Ok(new
    {
        Message =
            "The enrollment was completed successfully.",

        Success = true
    });
}

// ======================================================
// SUSPEND ENROLLMENT
// ======================================================

[HttpPut("suspend/{enrollmentId:long}")]
public async Task<IActionResult>
    SuspendEnrollment(
        long enrollmentId)
{
    var result = await _enrollmentService
        .SuspendEnrollmentAsync(
            enrollmentId);

    if (!result)
    {
        return BadRequest(
            "The enrollment could not be suspended.");
    }

    return Ok(new
    {
        Message =
            "The enrollment was suspended successfully.",

        Success = true
    });
}

// ======================================================
// CANCEL ENROLLMENT
// ======================================================

[HttpPut("cancel/{enrollmentId:long}")]
public async Task<IActionResult>
    CancelEnrollment(
        long enrollmentId)
{
    var result = await _enrollmentService
        .CancelEnrollmentAsync(
            enrollmentId);

    if (!result)
    {
        return BadRequest(
            "The enrollment could not be cancelled.");
    }

    return Ok(new
    {
        Message =
            "The enrollment was cancelled successfully.",

        Success = true
    });
}

// ======================================================
// UPDATE LEARNING PROGRESS
// ======================================================

[HttpPut(
    "{enrollmentId:long}" +
    "/progress/{progressPercentage:decimal}")]
public async Task<IActionResult>
    UpdateProgress(
        long enrollmentId,
        decimal progressPercentage)
{
    var result = await _enrollmentService
        .UpdateProgressAsync(
            enrollmentId,
            progressPercentage);

    if (!result)
    {
        return BadRequest(
            "The enrollment progress could not be updated.");
    }

    return Ok(new
    {
        Message =
            "The enrollment progress was updated successfully.",

        Success = true
    });
}

// ======================================================
// UPDATE LAST ACCESSED DATE
// ======================================================

[HttpPut(
    "{enrollmentId:long}/last-accessed")]
public async Task<IActionResult>
    UpdateLastAccessed(
        long enrollmentId)
{
    var result = await _enrollmentService
        .UpdateLastAccessedAsync(
            enrollmentId);

    if (!result)
    {
        return BadRequest(
            "The last accessed date could not be updated.");
    }

    return Ok(new
    {
        Message =
            "The last accessed date was updated successfully.",

        Success = true
    });
}

// ======================================================
// UPDATE CERTIFICATE ELIGIBILITY
// ======================================================

[HttpPut(
    "{enrollmentId:long}" +
    "/certificate-eligibility/{isEligible:bool}")]
public async Task<IActionResult>
    UpdateCertificateEligibility(
        long enrollmentId,
        bool isEligible)
{
    var result = await _enrollmentService
        .UpdateCertificateEligibilityAsync(
            enrollmentId,
            isEligible);

    if (!result)
    {
        return BadRequest(
            "The certificate eligibility could not be updated.");
    }

    return Ok(new
    {
        Message =
            "The certificate eligibility was updated successfully.",

        Success = true
    });
}

// ======================================================
// CHECK ENROLLMENT EXISTS
// ======================================================

[HttpGet("exists/{enrollmentId:long}")]
public async Task<IActionResult>
    Exists(
        long enrollmentId)
{
    var result = await _enrollmentService
        .ExistsAsync(
            enrollmentId);

    return Ok(new
    {
        EnrollmentId = enrollmentId,

        Exists = result
    });
}

}

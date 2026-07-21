using LMS.Shared.DTOs.Students;
namespace LMS.Application.Interfaces;

public interface IStudentService
{
    // ============================
    // Student Profile
    // ============================

    Task<StudentProfileDto?> GetStudentByIdAsync(long studentProfileId);

    Task<StudentProfileDto?> GetStudentByUserIdAsync(string userId);

    Task<List<StudentSummaryDto>> GetAllStudentsAsync();

    Task<bool> CreateStudentProfileAsync(CreateStudentProfileDto dto);

    Task<bool> UpdateStudentProfileAsync(UpdateStudentProfileDto dto);

    Task<bool> DeleteStudentProfileAsync(long studentProfileId);

    Task<bool> ActivateStudentAsync(long studentProfileId);

    Task<bool> DeactivateStudentAsync(long studentProfileId);
}
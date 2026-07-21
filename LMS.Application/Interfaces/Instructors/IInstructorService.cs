using LMS.Shared.DTOs.Instructors;

namespace LMS.Application.Interfaces;

public interface IInstructorService
{
    Task<InstructorProfileDto?> GetInstructorByIdAsync(
        long instructorProfileId);

    Task<InstructorProfileDto?> GetInstructorByUserIdAsync(
        string userId);

    Task<List<InstructorSummaryDto>>
        GetAllInstructorsAsync();

    Task<bool> CreateInstructorProfileAsync(
        CreateInstructorProfileDto dto);

    Task<bool> UpdateInstructorProfileAsync(
        UpdateInstructorProfileDto dto);

    Task<bool> DeleteInstructorProfileAsync(
        long instructorProfileId);

    Task<bool> ActivateInstructorAsync(
        long instructorProfileId);

    Task<bool> DeactivateInstructorAsync(
        long instructorProfileId);
}
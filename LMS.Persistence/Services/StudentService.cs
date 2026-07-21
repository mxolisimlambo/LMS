using LMS.Application.Interfaces;
using LMS.Domain.Entities.Students;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Students;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }
public async Task<StudentProfileDto?> GetStudentByIdAsync(
    long studentProfileId)
{
    return await _context.StudentProfiles
        .Where(x => x.StudentProfileId == studentProfileId)
        .Select(x => new StudentProfileDto
        {
            StudentProfileId = x.StudentProfileId,
            UserId = x.UserId,
            StudentNumber = x.StudentNumber,
            Occupation = x.Occupation,
            Company = x.Company,
            ProfilePhoto = x.ProfilePhoto,
            IsPremium = x.IsPremium,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsDeleted = x.IsDeleted
        })
        .FirstOrDefaultAsync();
}
public async Task<StudentProfileDto?> GetStudentByUserIdAsync(
    string userId)
{
    return await _context.StudentProfiles
        .Where(x => x.UserId == userId)
        .Select(x => new StudentProfileDto
        {
            StudentProfileId = x.StudentProfileId,
            UserId = x.UserId,
            StudentNumber = x.StudentNumber,
            Occupation = x.Occupation,
            Company = x.Company,
            ProfilePhoto = x.ProfilePhoto,
            IsPremium = x.IsPremium,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsDeleted = x.IsDeleted
        })
        .FirstOrDefaultAsync();
}
public async Task<List<StudentSummaryDto>> GetAllStudentsAsync()
{
    return await _context.StudentProfiles
        .OrderBy(x => x.StudentNumber)
        .Select(x => new StudentSummaryDto
        {
            StudentProfileId = x.StudentProfileId,
            StudentNumber = x.StudentNumber,
            UserId = x.UserId,
            Occupation = x.Occupation,
            Company = x.Company,
            IsPremium = x.IsPremium,
            IsDeleted = x.IsDeleted
        })
        .ToListAsync();
}
public async Task<bool> CreateStudentProfileAsync(
    CreateStudentProfileDto dto)
{
    var exists = await _context.StudentProfiles
        .AnyAsync(x => x.UserId == dto.UserId);

    if (exists)
        return false;

    var student = new StudentProfile
    {
        UserId = dto.UserId,
        StudentNumber = $"STU{DateTime.UtcNow.Ticks}",
        Occupation = dto.Occupation,
        Company = dto.Company,
        ProfilePhoto = dto.ProfilePhoto,
        IsPremium = dto.IsPremium,
        CreatedDate = DateTime.UtcNow,
        IsDeleted = false
    };

    _context.StudentProfiles.Add(student);

    await _context.SaveChangesAsync();

    return true;
}

   public async Task<bool> UpdateStudentProfileAsync(
    UpdateStudentProfileDto dto)
{
    var student = await _context.StudentProfiles
        .FirstOrDefaultAsync(x =>
            x.StudentProfileId == dto.StudentProfileId);

    if (student == null)
        return false;

    student.Occupation = dto.Occupation;
    student.Company = dto.Company;
    student.ProfilePhoto = dto.ProfilePhoto;
    student.IsPremium = dto.IsPremium;
    student.UpdatedDate = DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

   public async Task<bool> DeleteStudentProfileAsync(
    long studentProfileId)
{
    var student = await _context.StudentProfiles
        .FirstOrDefaultAsync(x =>
            x.StudentProfileId == studentProfileId);

    if (student == null)
        return false;

    student.IsDeleted = true;
    student.UpdatedDate = DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

    public async Task<bool> ActivateStudentAsync(
    long studentProfileId)
{
    var student = await _context.StudentProfiles
        .FirstOrDefaultAsync(x =>
            x.StudentProfileId == studentProfileId);

    if (student == null)
        return false;

    student.IsDeleted = false;
    student.UpdatedDate = DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}

    public async Task<bool> DeactivateStudentAsync(
    long studentProfileId)
{
    var student = await _context.StudentProfiles
        .FirstOrDefaultAsync(x =>
            x.StudentProfileId == studentProfileId);

    if (student == null)
        return false;

    student.IsDeleted = true;
    student.UpdatedDate = DateTime.UtcNow;

    await _context.SaveChangesAsync();

    return true;
}
}
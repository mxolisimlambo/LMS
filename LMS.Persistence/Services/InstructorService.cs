using LMS.Application.Interfaces;
using LMS.Persistence.Context;
using LMS.Domain.Entities.Instructors;
using LMS.Shared.DTOs.Instructors;
using Microsoft.EntityFrameworkCore;


 
public class InstructorService : IInstructorService
{
    private readonly ApplicationDbContext _context;

    public InstructorService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<InstructorProfileDto?> GetInstructorByIdAsync(
        long instructorProfileId)
    {
        return await _context.InstructorProfiles
            .Where(x => x.InstructorProfileId == instructorProfileId)
            .Select(x => new InstructorProfileDto
            {
                InstructorProfileId = x.InstructorProfileId,
                UserId = x.UserId,
                InstructorNumber = x.InstructorNumber,
                ProfessionalHeadline = x.ProfessionalHeadline,
                Biography = x.Biography,
                ProfilePhoto = x.ProfilePhoto,
                BannerImage = x.BannerImage,
                Website = x.Website,
                YearsExperience = x.YearsExperience,
                AverageRating = x.AverageRating,
                TotalStudents = x.TotalStudents,
                TotalCourses = x.TotalCourses,
                TotalSales = x.TotalSales,
                WalletBalance = x.WalletBalance,
                ApprovalStatus = x.ApprovalStatus,
                VerificationStatus = x.VerificationStatus,
                IsPremium = x.IsPremium,
                CreatedDate = x.CreatedDate
            })
            .FirstOrDefaultAsync();
    }

    public async Task<InstructorProfileDto?> GetInstructorByUserIdAsync(
        string userId)
    {
        return await _context.InstructorProfiles
            .Where(x => x.UserId == userId)
            .Select(x => new InstructorProfileDto
            {
                InstructorProfileId = x.InstructorProfileId,
                UserId = x.UserId,
                InstructorNumber = x.InstructorNumber,
                ProfessionalHeadline = x.ProfessionalHeadline,
                Biography = x.Biography,
                ProfilePhoto = x.ProfilePhoto,
                BannerImage = x.BannerImage,
                Website = x.Website,
                YearsExperience = x.YearsExperience,
                AverageRating = x.AverageRating,
                TotalStudents = x.TotalStudents,
                TotalCourses = x.TotalCourses,
                TotalSales = x.TotalSales,
                WalletBalance = x.WalletBalance,
                ApprovalStatus = x.ApprovalStatus,
                VerificationStatus = x.VerificationStatus,
                IsPremium = x.IsPremium,
                CreatedDate = x.CreatedDate
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<InstructorSummaryDto>> GetAllInstructorsAsync()
    {
        return await _context.InstructorProfiles
            .OrderBy(x => x.InstructorNumber)
            .Select(x => new InstructorSummaryDto
            {
                InstructorProfileId = x.InstructorProfileId,
                InstructorNumber = x.InstructorNumber,
                ProfessionalHeadline = x.ProfessionalHeadline,
                AverageRating = x.AverageRating,
                TotalStudents = x.TotalStudents,
                TotalCourses = x.TotalCourses,
                IsPremium = x.IsPremium
            })
            .ToListAsync();
    }

    public async Task<bool> CreateInstructorProfileAsync(
        CreateInstructorProfileDto dto)
    {
        var exists = await _context.InstructorProfiles
            .AnyAsync(x => x.UserId == dto.UserId);

        if (exists)
            return false;

        var instructor = new InstructorProfile
        {
            UserId = dto.UserId,
            InstructorNumber = $"INS{DateTime.UtcNow.Ticks}",
            ProfessionalHeadline = dto.ProfessionalHeadline,
            Biography = dto.Biography,
            ProfilePhoto = dto.ProfilePhoto,
            BannerImage = dto.BannerImage,
            Website = dto.Website,
            YearsExperience = dto.YearsExperience,

            AverageRating = 0,
            TotalStudents = 0,
            TotalCourses = 0,
            TotalSales = 0,
            WalletBalance = 0,

            ApprovalStatus = "Pending",
            VerificationStatus = "Pending",

            IsPremium = dto.IsPremium,

            CreatedDate = DateTime.UtcNow,
            UpdatedDate = null,
            IsDeleted = false
        };

        _context.InstructorProfiles.Add(instructor);

        await _context.SaveChangesAsync();

        return true;
    }
        public async Task<bool> UpdateInstructorProfileAsync(
        UpdateInstructorProfileDto dto)
    {
        var instructor = await _context.InstructorProfiles
            .FirstOrDefaultAsync(x =>
                x.InstructorProfileId == dto.InstructorProfileId);

        if (instructor == null)
            return false;

        instructor.ProfessionalHeadline = dto.ProfessionalHeadline;
        instructor.Biography = dto.Biography;
        instructor.ProfilePhoto = dto.ProfilePhoto;
        instructor.BannerImage = dto.BannerImage;
        instructor.Website = dto.Website;
        instructor.YearsExperience = dto.YearsExperience;
        instructor.IsPremium = dto.IsPremium;
        instructor.IsDeleted = dto.IsDeleted;
        instructor.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteInstructorProfileAsync(
        long instructorProfileId)
    {
        var instructor = await _context.InstructorProfiles
            .FirstOrDefaultAsync(x =>
                x.InstructorProfileId == instructorProfileId);

        if (instructor == null)
            return false;

        instructor.IsDeleted = true;
        instructor.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ActivateInstructorAsync(
        long instructorProfileId)
    {
        var instructor = await _context.InstructorProfiles
            .FirstOrDefaultAsync(x =>
                x.InstructorProfileId == instructorProfileId);

        if (instructor == null)
            return false;

        instructor.IsDeleted = false;
        instructor.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeactivateInstructorAsync(
        long instructorProfileId)
    {
        var instructor = await _context.InstructorProfiles
            .FirstOrDefaultAsync(x =>
                x.InstructorProfileId == instructorProfileId);

        if (instructor == null)
            return false;

        instructor.IsDeleted = true;
        instructor.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

}
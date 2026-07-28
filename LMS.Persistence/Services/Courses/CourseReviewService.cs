using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Reviews;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.Reviews;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Courses;

public class CourseReviewService : ICourseReviewService
{
    private readonly ApplicationDbContext _context;

    public CourseReviewService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateReviewAsync(
        CreateCourseReviewDto dto)
    {
        var review = new CourseReview
        {
            CourseId = dto.CourseId,
            StudentProfileId = dto.StudentProfileId,
            ReviewTitle = dto.ReviewTitle,
            Review = dto.Review,
            IsRecommended = dto.IsRecommended,

            IsApproved = false,
            ApprovedDate = null,
            ApprovedBy = null,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseReviews.Add(review);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateReviewAsync(
        UpdateCourseReviewDto dto)
    {
        var review = await _context.CourseReviews
            .FirstOrDefaultAsync(x =>
                x.CourseReviewId == dto.CourseReviewId);

        if (review == null)
            return false;

        review.ReviewTitle = dto.ReviewTitle;
        review.Review = dto.Review;
        review.IsRecommended = dto.IsRecommended;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteReviewAsync(
        long courseReviewId)
    {
        var review = await _context.CourseReviews
            .FirstOrDefaultAsync(x =>
                x.CourseReviewId == courseReviewId);

        if (review == null)
            return false;

        review.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> CreateRatingAsync(
        CreateCourseRatingDto dto)
    {
        var exists = await _context.CourseRatings
            .AnyAsync(x =>
                x.CourseId == dto.CourseId &&
                x.StudentProfileId == dto.StudentProfileId);

        if (exists)
            return false;

        var rating = new CourseRating
        {
            CourseId = dto.CourseId,
            StudentProfileId = dto.StudentProfileId,
            Rating = dto.Rating,
            IsVerifiedPurchase = dto.IsVerifiedPurchase,
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseRatings.Add(rating);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<CourseReviewDto>>
        GetCourseReviewsAsync(
            long courseId)
    {
        return await _context.CourseReviews
            .Where(x =>
                x.CourseId == courseId &&
                !x.IsDeleted)
            .OrderByDescending(x => x.CreatedDate)
            .Select(x => new CourseReviewDto
            {
                CourseReviewId = x.CourseReviewId,
                CourseId = x.CourseId,
                StudentProfileId = x.StudentProfileId,
                ReviewTitle = x.ReviewTitle,
                Review = x.Review,
                IsRecommended = x.IsRecommended,
                IsApproved = x.IsApproved,
                ApprovedDate = x.ApprovedDate,
                ApprovedBy = x.ApprovedBy,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted
            })
            .ToListAsync();
    }

    public async Task<decimal> GetAverageRatingAsync(
        long courseId)
    {
        var ratings = await _context.CourseRatings
            .Where(x =>
                x.CourseId == courseId &&
                !x.IsDeleted)
            .Select(x => x.Rating)
            .ToListAsync();

        if (!ratings.Any())
            return 0;

        return Math.Round(ratings.Average(), 2);
    }
}

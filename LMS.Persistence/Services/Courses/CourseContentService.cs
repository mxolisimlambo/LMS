using LMS.Application.Interfaces.Courses;
using LMS.Domain.Entities.Courses.Content;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Courses.Content;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Courses;

public class CourseContentService : ICourseContentService
{
    private readonly ApplicationDbContext _context;

    public CourseContentService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    // ======================================================
    // Videos
    // ======================================================

    public async Task<bool> CreateVideoAsync(
        CreateCourseVideoDto dto)
    {
        var video = new CourseVideo
        {
            CourseLessonId = dto.CourseLessonId,
            VideoTitle = dto.Title,
            VideoUrl = dto.VideoUrl,
            DurationMinutes = dto.DurationInSeconds / 60m,

            Thumbnail = string.Empty,
            FileSize = 0,
            IsDownloadable = false,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseVideos.Add(video);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateVideoAsync(
        UpdateCourseVideoDto dto)
    {
        var video = await _context.CourseVideos
            .FirstOrDefaultAsync(x =>
                x.CourseVideoId == dto.CourseVideoId);

        if (video == null)
            return false;

        video.VideoTitle = dto.Title;
        video.VideoUrl = dto.VideoUrl;
        video.DurationMinutes = dto.DurationInSeconds / 60m;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteVideoAsync(
        long courseVideoId)
    {
        var video = await _context.CourseVideos
            .FirstOrDefaultAsync(x =>
                x.CourseVideoId == courseVideoId);

        if (video == null)
            return false;

        video.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

    // ======================================================
    // Documents
    // ======================================================

    public async Task<bool> CreateDocumentAsync(
        CreateCourseDocumentDto dto)
    {
        var document = new CourseDocument
        {
            CourseLessonId = dto.CourseLessonId,
            DocumentTitle = dto.Title,

            FilePath = dto.FilePath,
            FileName = Path.GetFileName(dto.FilePath),
            FileType = Path.GetExtension(dto.FilePath),

            FileSize = 0,
            IsDownloadable = true,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseDocuments.Add(document);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateDocumentAsync(
        UpdateCourseDocumentDto dto)
    {
        var document = await _context.CourseDocuments
            .FirstOrDefaultAsync(x =>
                x.CourseDocumentId == dto.CourseDocumentId);

        if (document == null)
            return false;

        document.DocumentTitle = dto.Title;
        document.FilePath = dto.FilePath;
        document.FileName = Path.GetFileName(dto.FilePath);
        document.FileType = Path.GetExtension(dto.FilePath);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteDocumentAsync(
        long courseDocumentId)
    {
        var document = await _context.CourseDocuments
            .FirstOrDefaultAsync(x =>
                x.CourseDocumentId == courseDocumentId);

        if (document == null)
            return false;

        document.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

    // ======================================================
    // Attachments
    // ======================================================

    public async Task<bool> CreateAttachmentAsync(
        CreateCourseAttachmentDto dto)
    {
        var attachment = new CourseAttachment
        {
            CourseLessonId = dto.CourseLessonId,
            AttachmentTitle = dto.Title,

            FilePath = dto.FilePath,
            FileName = Path.GetFileName(dto.FilePath),
            FileType = Path.GetExtension(dto.FilePath),

            FileSize = 0,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseAttachments.Add(attachment);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAttachmentAsync(
        UpdateCourseAttachmentDto dto)
    {
        var attachment = await _context.CourseAttachments
            .FirstOrDefaultAsync(x =>
                x.CourseAttachmentId == dto.CourseAttachmentId);

        if (attachment == null)
            return false;

        attachment.AttachmentTitle = dto.Title;
        attachment.FilePath = dto.FilePath;
        attachment.FileName = Path.GetFileName(dto.FilePath);
        attachment.FileType = Path.GetExtension(dto.FilePath);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAttachmentAsync(
        long courseAttachmentId)
    {
        var attachment = await _context.CourseAttachments
            .FirstOrDefaultAsync(x =>
                x.CourseAttachmentId == courseAttachmentId);

        if (attachment == null)
            return false;

        attachment.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

    // ======================================================
    // Resources
    // ======================================================

    public async Task<bool> CreateResourceAsync(
        CreateCourseResourceDto dto)
    {
        var lesson = await _context.CourseLessons
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.CourseLessonId == dto.CourseLessonId);

        if (lesson == null)
            return false;

        var module = await _context.CourseModules
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.CourseModuleId == lesson.CourseModuleId);

        if (module == null)
            return false;

        var resource = new CourseResource
        {
            CourseId = module.CourseId,
            ResourceName = dto.ResourceName,
            ResourceUrl = dto.ResourceUrl,

            DisplayOrder = 1,

            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.CourseResources.Add(resource);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateResourceAsync(
        UpdateCourseResourceDto dto)
    {
        var resource = await _context.CourseResources
            .FirstOrDefaultAsync(x =>
                x.CourseResourceId == dto.CourseResourceId);

        if (resource == null)
            return false;

        resource.ResourceName = dto.ResourceName;
        resource.ResourceUrl = dto.ResourceUrl;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteResourceAsync(
        long courseResourceId)
    {
        var resource = await _context.CourseResources
            .FirstOrDefaultAsync(x =>
                x.CourseResourceId == courseResourceId);

        if (resource == null)
            return false;

        resource.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

}

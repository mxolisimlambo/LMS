using LMS.Shared.DTOs.Courses.Content;

namespace LMS.Application.Interfaces.Courses;

public interface ICourseContentService
{
    Task<bool> CreateVideoAsync(CreateCourseVideoDto dto);

    Task<bool> UpdateVideoAsync(UpdateCourseVideoDto dto);

    Task<bool> DeleteVideoAsync(long courseVideoId);

    Task<bool> CreateDocumentAsync(CreateCourseDocumentDto dto);

    Task<bool> UpdateDocumentAsync(UpdateCourseDocumentDto dto);

    Task<bool> DeleteDocumentAsync(long courseDocumentId);

    Task<bool> CreateAttachmentAsync(CreateCourseAttachmentDto dto);

    Task<bool> UpdateAttachmentAsync(UpdateCourseAttachmentDto dto);

    Task<bool> DeleteAttachmentAsync(long courseAttachmentId);

    Task<bool> CreateResourceAsync(CreateCourseResourceDto dto);

    Task<bool> UpdateResourceAsync(UpdateCourseResourceDto dto);

    Task<bool> DeleteResourceAsync(long courseResourceId);
}

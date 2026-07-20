namespace LMS.Domain.Entities.Students;

public class StudentDocument
{
    public long StudentDocumentId { get; set; }

    public long StudentProfileId { get; set; }

    public string DocumentType { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string OriginalFileName { get; set; } = string.Empty;

    public string FileExtension { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long FileSize { get; set; }

    public string FilePath { get; set; } = string.Empty;

    public bool IsVerified { get; set; }

    public DateTime UploadedDate { get; set; }

    public DateTime? VerifiedDate { get; set; }

    public bool IsDeleted { get; set; }
    public StudentProfile? StudentProfile { get; set; }
}
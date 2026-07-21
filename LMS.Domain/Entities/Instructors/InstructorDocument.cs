namespace LMS.Domain.Entities.Instructors;

public class InstructorDocument
{
    public long InstructorDocumentId { get; set; }

    public long InstructorProfileId { get; set; }

    public string DocumentType { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public bool Verified { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public InstructorProfile? InstructorProfile { get; set; }
}


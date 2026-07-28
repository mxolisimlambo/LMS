//======================================================
// CoursePriceDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Commerce;

public class CoursePriceDto
{
    public long CoursePriceId { get; set; }

    public long CourseId { get; set; }

    public decimal Price { get; set; }

    public string Currency { get; set; } = "ZAR";

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

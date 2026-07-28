//======================================================
// CreateCoursePriceDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Commerce;

public class CreateCoursePriceDto
{
    public long CourseId { get; set; }

    public decimal Price { get; set; }

    public string Currency { get; set; } = "ZAR";
}

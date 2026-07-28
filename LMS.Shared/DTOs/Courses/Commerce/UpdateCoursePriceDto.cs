//======================================================
// UpdateCoursePriceDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Commerce;

public class UpdateCoursePriceDto
{
    public long CoursePriceId { get; set; }

    public decimal Price { get; set; }

    public string Currency { get; set; } = "ZAR";
}

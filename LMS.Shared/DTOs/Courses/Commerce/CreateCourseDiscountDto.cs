//======================================================
// CreateCourseDiscountDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Commerce;

public class CreateCourseDiscountDto
{
    public long CourseId { get; set; }

    public decimal DiscountAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}

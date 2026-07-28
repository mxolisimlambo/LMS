//======================================================
// UpdateCourseDiscountDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Commerce;

public class UpdateCourseDiscountDto
{
    public long CourseDiscountId { get; set; }

    public decimal DiscountAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}

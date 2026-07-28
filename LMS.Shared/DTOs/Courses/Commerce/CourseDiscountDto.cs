//======================================================
// CourseDiscountDto.cs
//======================================================

namespace LMS.Shared.DTOs.Courses.Commerce;

public class CourseDiscountDto
{
    public long CourseDiscountId { get; set; }

    public long CourseId { get; set; }

    public decimal DiscountAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}

using LMS.Application.Interfaces.Courses;
using LMS.Shared.DTOs.Courses.CourseCategory;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Courses;

[ApiController]
[ApiExplorerSettings(GroupName = "coursecategory")]
[Route("api/course-categories")]
public class CourseCategoryController : ControllerBase
{
    private readonly ICourseCategoryService _service;

    public CourseCategoryController(
        ICourseCategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllCourseCategoriesAsync());
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _service.GetCourseCategoryByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCourseCategoryDto dto)
    {
        return Ok(await _service.CreateCourseCategoryAsync(dto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateCourseCategoryDto dto)
    {
        return Ok(await _service.UpdateCourseCategoryAsync(dto));
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await _service.DeleteCourseCategoryAsync(id));
    }
}

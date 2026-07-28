using LMS.Application.Interfaces.Courses;
using LMS.Shared.DTOs.Courses.CourseSubCategory;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Courses;

[ApiController]
[ApiExplorerSettings(GroupName = "coursesubcategory")]
[Route("api/course-sub-categories")]
public class CourseSubCategoryController : ControllerBase
{
    private readonly ICourseSubCategoryService _service;

    public CourseSubCategoryController(
        ICourseSubCategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllCourseSubCategoriesAsync());
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _service.GetCourseSubCategoryByIdAsync(id));
    }

    [HttpGet("category/{courseCategoryId:long}")]
    public async Task<IActionResult> GetByCategory(long courseCategoryId)
    {
        return Ok(await _service.GetByCategoryAsync(courseCategoryId));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCourseSubCategoryDto dto)
    {
        return Ok(await _service.CreateCourseSubCategoryAsync(dto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateCourseSubCategoryDto dto)
    {
        return Ok(await _service.UpdateCourseSubCategoryAsync(dto));
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await _service.DeleteCourseSubCategoryAsync(id));
    }
}

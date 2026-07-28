using LMS.Application.Interfaces.Courses;
using LMS.Shared.DTOs.Courses.CourseLanguage;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Courses;

[ApiController]
[ApiExplorerSettings(GroupName = "courselanguage")]
[Route("api/course-languages")]
public class CourseLanguageController : ControllerBase
{
    private readonly ICourseLanguageService _service;

    public CourseLanguageController(
        ICourseLanguageService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllCourseLanguagesAsync());
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _service.GetCourseLanguageByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCourseLanguageDto dto)
    {
        return Ok(await _service.CreateCourseLanguageAsync(dto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateCourseLanguageDto dto)
    {
        return Ok(await _service.UpdateCourseLanguageAsync(dto));
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await _service.DeleteCourseLanguageAsync(id));
    }
}

using LMS.Application.Interfaces.Courses;
using LMS.Shared.DTOs.Courses.CourseLevel;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Courses;

[ApiController]
[ApiExplorerSettings(GroupName = "courselevel")]
[Route("api/course-levels")]
public class CourseLevelController : ControllerBase
{
    private readonly ICourseLevelService _service;

    public CourseLevelController(
        ICourseLevelService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllCourseLevelsAsync());
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _service.GetCourseLevelByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCourseLevelDto dto)
    {
        return Ok(await _service.CreateCourseLevelAsync(dto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateCourseLevelDto dto)
    {
        return Ok(await _service.UpdateCourseLevelAsync(dto));
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await _service.DeleteCourseLevelAsync(id));
    }
}

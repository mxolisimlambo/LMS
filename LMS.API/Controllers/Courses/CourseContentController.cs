using LMS.Application.Interfaces.Courses;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Courses.Content;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "coursecontent")]
[Route("api/[controller]")]
//[Authorize]
public class CourseContentController : ControllerBase
{
    private readonly ICourseContentService _courseContentService;

    public CourseContentController(
        ICourseContentService courseContentService)
    {
        _courseContentService = courseContentService;
    }


    // ======================================================
    // VIDEOS
    // ======================================================


    // CREATE VIDEO
    [HttpPost("video")]
    //  [Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateVideo(
        CreateCourseVideoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseContentService
            .CreateVideoAsync(dto);


        if (!created)
            return BadRequest("Unable to create video.");


        return Ok(new
        {
            Message = "Course video created successfully."
        });
    }



    // UPDATE VIDEO
    [HttpPut("video")]
    // [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateVideo(
        UpdateCourseVideoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var updated = await _courseContentService
            .UpdateVideoAsync(dto);


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Course video updated successfully."
        });
    }



    // DELETE VIDEO
    [HttpDelete("video/{courseVideoId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteVideo(
        long courseVideoId)
    {
        var deleted = await _courseContentService
            .DeleteVideoAsync(courseVideoId);


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Course video deleted successfully."
        });
    }




    // ======================================================
    // DOCUMENTS
    // ======================================================


    // CREATE DOCUMENT
    [HttpPost("document")]
    //[Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateDocument(
        CreateCourseDocumentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseContentService
            .CreateDocumentAsync(dto);


        if (!created)
            return BadRequest("Unable to create document.");


        return Ok(new
        {
            Message = "Course document created successfully."
        });
    }




    // UPDATE DOCUMENT
    [HttpPut("document")]
    //  [Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateDocument(
        UpdateCourseDocumentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var updated = await _courseContentService
            .UpdateDocumentAsync(dto);


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Course document updated successfully."
        });
    }




    // DELETE DOCUMENT
    [HttpDelete("document/{courseDocumentId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteDocument(
        long courseDocumentId)
    {
        var deleted = await _courseContentService
            .DeleteDocumentAsync(courseDocumentId);


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Course document deleted successfully."
        });
    }





    // ======================================================
    // ATTACHMENTS
    // ======================================================


    // CREATE ATTACHMENT
    [HttpPost("attachment")]
    //[Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateAttachment(
        CreateCourseAttachmentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseContentService
            .CreateAttachmentAsync(dto);


        if (!created)
            return BadRequest("Unable to create attachment.");


        return Ok(new
        {
            Message = "Course attachment created successfully."
        });
    }




    // UPDATE ATTACHMENT
    [HttpPut("attachment")]
    //[Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateAttachment(
        UpdateCourseAttachmentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var updated = await _courseContentService
            .UpdateAttachmentAsync(dto);


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Course attachment updated successfully."
        });
    }




    // DELETE ATTACHMENT
    [HttpDelete("attachment/{courseAttachmentId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteAttachment(
        long courseAttachmentId)
    {
        var deleted = await _courseContentService
            .DeleteAttachmentAsync(courseAttachmentId);


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Course attachment deleted successfully."
        });
    }





    // ======================================================
    // RESOURCES
    // ======================================================


    // CREATE RESOURCE
    [HttpPost("resource")]
    //[Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateResource(
        CreateCourseResourceDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseContentService
            .CreateResourceAsync(dto);


        if (!created)
            return BadRequest("Unable to create resource.");


        return Ok(new
        {
            Message = "Course resource created successfully."
        });
    }




    // UPDATE RESOURCE
    [HttpPut("resource")]
    //[Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateResource(
        UpdateCourseResourceDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var updated = await _courseContentService
            .UpdateResourceAsync(dto);


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Course resource updated successfully."
        });
    }




    // DELETE RESOURCE
    [HttpDelete("resource/{courseResourceId:long}")]
    // [Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteResource(
        long courseResourceId)
    {
        var deleted = await _courseContentService
            .DeleteResourceAsync(courseResourceId);


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Course resource deleted successfully."
        });
    }

}

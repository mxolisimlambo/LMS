using LMS.Application.Interfaces.Courses;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Courses.Commerce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "coursecommerce")]
[Route("api/[controller]")]
//[Authorize]
public class CourseCommerceController : ControllerBase
{
    private readonly ICourseCommerceService _courseCommerceService;

    public CourseCommerceController(
        ICourseCommerceService courseCommerceService)
    {
        _courseCommerceService = courseCommerceService;
    }



    // ======================================================
    // COURSE PRICE
    // ======================================================


    // CREATE PRICE
    [HttpPost("price")]
    // [Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreatePrice(
        CreateCoursePriceDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseCommerceService
            .CreatePriceAsync(dto);


        if (!created)
            return BadRequest(
                "Course price already exists.");


        return Ok(new
        {
            Message = "Course price created successfully."
        });
    }



    // UPDATE PRICE
    [HttpPut("price")]
    //[Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdatePrice(
        UpdateCoursePriceDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var updated = await _courseCommerceService
            .UpdatePriceAsync(dto);


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Course price updated successfully."
        });
    }





    // ======================================================
    // COURSE DISCOUNT
    // ======================================================


    // CREATE DISCOUNT
    [HttpPost("discount")]
    //[Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateDiscount(
        CreateCourseDiscountDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseCommerceService
            .CreateDiscountAsync(dto);


        if (!created)
            return BadRequest(
                "Unable to create course discount.");


        return Ok(new
        {
            Message = "Course discount created successfully."
        });
    }




    // UPDATE DISCOUNT
    [HttpPut("discount")]
    //[Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateDiscount(
        UpdateCourseDiscountDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var updated = await _courseCommerceService
            .UpdateDiscountAsync(dto);


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Course discount updated successfully."
        });
    }




    // DELETE DISCOUNT
    [HttpDelete("discount/{courseDiscountId:long}")]
    //[Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteDiscount(
        long courseDiscountId)
    {
        var deleted = await _courseCommerceService
            .DeleteDiscountAsync(courseDiscountId);


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Course discount deleted successfully."
        });
    }





    // ======================================================
    // COURSE COUPON
    // ======================================================


    // CREATE COUPON
    [HttpPost("coupon")]
    [Authorize(Policy = PermissionConstants.Courses.Create)]
    public async Task<IActionResult> CreateCoupon(
        CreateCourseCouponDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var created = await _courseCommerceService
            .CreateCouponAsync(dto);


        if (!created)
            return BadRequest(
                "Coupon code already exists.");


        return Ok(new
        {
            Message = "Course coupon created successfully."
        });
    }




    // UPDATE COUPON
    [HttpPut("coupon")]
    //[Authorize(Policy = PermissionConstants.Courses.Update)]
    public async Task<IActionResult> UpdateCoupon(
        UpdateCourseCouponDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var updated = await _courseCommerceService
            .UpdateCouponAsync(dto);


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Course coupon updated successfully."
        });
    }




    // DELETE COUPON
    [HttpDelete("coupon/{courseCouponId:long}")]
    // [Authorize(Policy = PermissionConstants.Courses.Delete)]
    public async Task<IActionResult> DeleteCoupon(
        long courseCouponId)
    {
        var deleted = await _courseCommerceService
            .DeleteCouponAsync(courseCouponId);


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Course coupon deleted successfully."
        });
    }




    // ======================================================
    // VALIDATE COUPON
    // ======================================================


    [HttpGet("coupon/validate/{couponCode}")]
    // [Authorize(Policy = PermissionConstants.Courses.View)]
    public async Task<IActionResult> ValidateCoupon(
        string couponCode)
    {
        var coupon = await _courseCommerceService
            .ValidateCouponAsync(couponCode);


        if (coupon == null)
            return NotFound(
                "Invalid or expired coupon.");


        return Ok(coupon);
    }
}

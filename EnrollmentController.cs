using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.DTOS.EnrollmentDtos;
using StudentManagementSystem.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/v1/enrollments")]
[ApiVersion("1.0")]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _service;

    public EnrollmentController(IEnrollmentService service)
    {
        _service = service;
    }
    //======================================
    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    [SwaggerOperation(Summary = "Enroll Student", Description = "Enroll a student into a course")]
    public async Task<IActionResult>CreateEnrollment(CreateEnrollmentRequestDTO dto)
    {
        await _service.CreateEnrollmentAsync(dto);
        return Ok();
    }

    //=============================================================
}
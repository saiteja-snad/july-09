using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.DTOS.Exam_ResultDtos;
using StudentManagementSystem.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/v1/results")]
[ApiVersion("1.0")]
public class ResultController : ControllerBase
{
    private readonly IResultService _service;

    public ResultController(IResultService service)
    {
        _service = service;
    }
    //========================================================
    [HttpPost]
    [Authorize(Roles = "TEACHER")]
    [SwaggerOperation(Summary = "Publish Result",Description = "Publish student examination result")]
    public async Task<IActionResult>PublishResult(PublishResultRequestDTO dto)
    {
        await _service.PublishResultAsync(dto);
        return Ok();
    }
}
using EnrollmentSystem.Application.Features.RegisterStudent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentSystem.WebAPIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ISender _sender;


    public StudentController(IMediator mediator, ISender sender)
    {
        _mediator = mediator;
        _sender = sender;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(new { message = "Student registered successfully." });
    }
}

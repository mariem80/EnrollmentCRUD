using EnrollmentSystem.Application.DTOs.Enrollment.Responses;
using EnrollmentSystem.Application.Features.DeleteStudentEnrollments;
using EnrollmentSystem.Application.Features.EnrollStudents;
using EnrollmentSystem.Application.Features.GetAllEnrollments;
using EnrollmentSystem.Application.Features.UpdateEnrollmentGrade;
using EnrollmentSystem.Application.Resources;
using EnrollmentSystem.WebAPIs.ApiResponse;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentSystem.WebAPIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentController(IMediator mediator, IValidator<EnrollStudentsCommand> enrollStudentsValidator) : ControllerBase
{
    [HttpPost("EnrollStudents")]
    public async Task<ActionResult<ApiResponse<List<EnrollmentResponse>>>> EnrollStudents([FromBody] EnrollStudentsCommand request)
    {
        var validationResult = await enrollStudentsValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ApiResponse<List<EnrollmentResponse>>( StatusCodes.Status400BadRequest, null, string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));
        }
        var result = await mediator.Send(request);

        return Ok(new ApiResponse<List<EnrollmentResponse>>( StatusCodes.Status200OK, result, Resource.ProcessedSuccessfully));
    }
    [HttpPut("UpdateEnrollmentGrade")]
    public async Task<IActionResult> UpdateEnrollment([FromBody] UpdateEnrollmentGradeCommand command)
    {
        var result = await mediator.Send(command);

        if (!result)
        {
            return BadRequest(new ApiResponse<bool>( StatusCodes.Status400BadRequest, false, Resource.Failed));
        }

        return Ok(new ApiResponse<bool>( StatusCodes.Status200OK, true, Resource.ProcessedSuccessfully));
    }

    [HttpGet("GetAllEnrollments")]
    public async Task<ActionResult<ApiResponse<List<EnrollmentDto>>>> GetAllEnrollments()
    {
        var result = await mediator.Send(new GetAllEnrollmentsQuery());

        if (result == null || result.Count == 0)
            return NotFound(new ApiResponse<List<EnrollmentDto>>(StatusCodes.Status404NotFound, null, Resource.NoEnrollmentsExist));

        return Ok(new ApiResponse<List<EnrollmentDto>>(StatusCodes.Status200OK, result, Resource.ProcessedSuccessfully));
    }
    [HttpDelete("DeleteStudentEnrollments")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteStudentEnrollments([FromQuery] int studentId)
    {
        var command = new DeleteStudentEnrollmentsCommand(studentId);
        var result = await mediator.Send(command);

        if (!result)
            return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, false, Resource.Failed));

        return Ok(new ApiResponse<bool>(StatusCodes.Status200OK, true, Resource.ProcessedSuccessfully));
    }
}

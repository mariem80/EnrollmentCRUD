using EnrollmentSystem.Application.DTOs.Student.Responses;
using EnrollmentSystem.Application.Features.DeleteStudent;
using EnrollmentSystem.Application.Features.GetAllStudents;
using EnrollmentSystem.Application.Features.RegisterStudent;
using EnrollmentSystem.Application.Features.UpdateStudent;
using EnrollmentSystem.Application.Resources;
using EnrollmentSystem.WebAPIs.ApiResponse;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EnrollmentSystem.WebAPIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IMediator mediator, IValidator<RegisterStudentCommand> registerStudentValidator, IValidator<UpdateStudentCommand> updateStudentValidator) : ControllerBase
{
    [HttpPost("RegisterStudent")]
    public async Task<ActionResult<ApiResponse<bool>>> RegisterStudent([FromBody] RegisterStudentCommand request)
    {
        var validationResult = await registerStudentValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, false, string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));

        var result = await mediator.Send(request);
        return Ok(new ApiResponse<bool>(StatusCodes.Status200OK, result, Resource.ProcessedSuccessfully));
    }

    [HttpGet("GetAllStudents")]
    public async Task<ActionResult<ApiResponse<List<StudentDto>>>> GetAllStudents()
    {
        var students = await mediator.Send(new GetAllStudentsQuery());

        if (students == null || !students.Any())
            return NotFound(new ApiResponse<List<StudentDto>>(StatusCodes.Status404NotFound, null, Resource.StudentNotFound));

        return Ok(new ApiResponse<List<StudentDto>>(StatusCodes.Status200OK, students, Resource.ProcessedSuccessfully));
    }
    [HttpPut("UpdateStudent")]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateStudent([FromBody] UpdateStudentCommand request)
    {
        var validationResult = await updateStudentValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, false, string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));
        await mediator.Send(request);
        return Ok(new ApiResponse<bool>(StatusCodes.Status200OK, true, Resource.ProcessedSuccessfully));
    }

    [HttpDelete("DeleteStudent")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteStudent([FromBody] DeleteStudentCommand request)
    {
        var result = await mediator.Send(request);

        if (!result)
            return NotFound(new ApiResponse<bool>(StatusCodes.Status404NotFound, false, Resource.StudentNotFound));

        return Ok(new ApiResponse<bool>(StatusCodes.Status200OK, true, Resource.ProcessedSuccessfully));
    }
}

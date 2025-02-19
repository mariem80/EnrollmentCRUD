using EnrollmentSystem.Domain.Exceptions;
using EnrollmentSystem.WebAPIs.ApiResponse;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace EnrollmentSystem.WebAPIs.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex) 
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        ApiResponse<object> response;

        switch (ex)
        {
            case ValidationException validationException:
                response = new ApiResponse<object>
                (
                    status: StatusCodes.Status400BadRequest,
                    data: null,
                    message: "Validation failed.",
                    errors: validationException.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray())
                );
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;

            case BusinessException businessException:
                response = new ApiResponse<object>
                (
                    status: businessException.StatusCode,
                    data: null,
                    message: businessException.Message
                );
                context.Response.StatusCode = businessException.StatusCode;
                break;
            case JsonException jsonException:
                response = new ApiResponse<object>
                (
                    status: StatusCodes.Status400BadRequest,
                    data: null,
                    message: jsonException.Message
                );
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;

            default:
                response = new ApiResponse<object>
                (
                    status: StatusCodes.Status500InternalServerError,
                    data: null,
                    message: "An unexpected error occurred."
                );
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
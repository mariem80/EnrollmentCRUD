using Microsoft.AspNetCore.Http;

namespace EnrollmentSystem.Domain.Exceptions;
public class BusinessException : Exception
{
    public int StatusCode { get; } = StatusCodes.Status400BadRequest;
    public BusinessException(string message) : base(message){}
}

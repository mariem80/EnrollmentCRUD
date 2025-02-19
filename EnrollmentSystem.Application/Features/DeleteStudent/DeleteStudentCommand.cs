using MediatR;

namespace EnrollmentSystem.Application.Features.DeleteStudent;

public sealed record DeleteStudentCommand(string Email) : IRequest<bool>;

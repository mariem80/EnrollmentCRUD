using MediatR;

namespace EnrollmentSystem.Application.Features.RegisterStudent;

public sealed record RegisterStudentCommand(string StudentName, string StudentEmail, string StudentPassword) : IRequest<bool>;

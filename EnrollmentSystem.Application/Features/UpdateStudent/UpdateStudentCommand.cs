using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.UpdateStudent;
public sealed record UpdateStudentCommand(string Email, string? NewName, string? NewEmail, string? NewPassword) : IRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.DeleteStudentEnrollments;

public sealed record DeleteStudentEnrollmentsCommand(int StudentId) : IRequest<bool>;


using EnrollmentSystem.Application.DTOs.Enrollment.Responses;
using EnrollmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.GetAllEnrollments;

public sealed record GetAllEnrollmentsQuery : IRequest<List<EnrollmentDto>>;


using EnrollmentSystem.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.UpdateEnrollmentGrade;

public sealed record UpdateEnrollmentGradeCommand(int StudentId, int CourseId, string NewGrade) : IRequest<bool>;

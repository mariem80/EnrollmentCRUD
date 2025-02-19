using EnrollmentSystem.Application.DTOs.Student.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.GetAllStudents;

public sealed record GetAllStudentsQuery : IRequest<List<StudentDto>> { }
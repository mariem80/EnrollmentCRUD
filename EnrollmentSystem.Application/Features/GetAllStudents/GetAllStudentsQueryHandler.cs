using AutoMapper;
using EnrollmentSystem.Application.DTOs.Student.Responses;
using EnrollmentSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.GetAllStudents;

public class GetAllStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<GetAllStudentsQuery, List<StudentDto>>
{
    public async Task<List<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await studentRepository.GetAllAsync();
        return mapper.Map<List<StudentDto>>(students);
    }
}

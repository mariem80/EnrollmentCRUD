using AutoMapper;
using EnrollmentSystem.Application.DTOs.Enrollment.Responses;
using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.GetAllEnrollments;
public class GetAllEnrollmentsQueryHandler(IEnrollmentRepository enrollmentRepository, IMapper mapper) : IRequestHandler<GetAllEnrollmentsQuery, List<EnrollmentDto>>
{
    public async Task<List<EnrollmentDto>> Handle(GetAllEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var enrollments = await enrollmentRepository.GetAllEnrollmentsAsync();
        return mapper.Map<List<EnrollmentDto>>(enrollments);
    }
}

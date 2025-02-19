using EnrollmentSystem.Application.DTOs.Enrollment.Responses;
using MediatR;

namespace EnrollmentSystem.Application.Features.EnrollStudents;

public record EnrollStudentsCommand(int CourseId, List<int> StudentIds) : IRequest<List<EnrollmentResponse>>;


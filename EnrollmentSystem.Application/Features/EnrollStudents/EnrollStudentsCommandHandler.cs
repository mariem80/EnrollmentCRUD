using EnrollmentSystem.Application.DTOs.Enrollment.Responses;
using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Application.Resources;
using EnrollmentSystem.Application.UnitOfWork;
using EnrollmentSystem.Domain.Entities;
using EnrollmentSystem.Domain.Enums;
using EnrollmentSystem.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.EnrollStudents;

public class EnrollStudentsCommandHandler(IStudentRepository studentRepository, ICourseRepository courseRepository, IUnitOfWork unitOfWork, IEnrollmentRepository enrollmentRepository) : IRequestHandler<EnrollStudentsCommand, List<EnrollmentResponse>>
{

    public async Task<List<EnrollmentResponse>> Handle(EnrollStudentsCommand request, CancellationToken cancellationToken)
    {
        var enrollments = new List<EnrollmentResponse>();
        var course = await courseRepository.GetByIdAsync(request.CourseId);
        if (course == null)
            throw new BusinessException(string.Format(Resource.CourseNotFound, request.CourseId));


        foreach (var studentId in request.StudentIds)
        {
            var student = await studentRepository.GetByIdAsync(studentId);
            if (student == null)
                throw new BusinessException(Resource.StudentNotFound);

            var existingEnrollment = await enrollmentRepository.GetEnrollmentAsync(studentId, request.CourseId);
            if (existingEnrollment != null)
                throw new BusinessException(Resource.EnrollmentExists);

            var newEnrollment = new Enrollment
            {
                StudentID = studentId,
                CourseID = request.CourseId,
                EnrollmentDate = DateTime.UtcNow,
                Grade = Grade.NotAvailable.ToString()
            };

            await enrollmentRepository.AddAsync(newEnrollment);
            enrollments.Add(new EnrollmentResponse(studentId, Resource.Success));
        }

        await unitOfWork.SaveChangesAsync();
        return enrollments;
    }


}

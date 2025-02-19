using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Application.Resources;
using EnrollmentSystem.Application.UnitOfWork;
using EnrollmentSystem.Domain.Enums;
using EnrollmentSystem.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.UpdateEnrollmentGrade;

public class UpdateEnrollmentGradeCommandHandler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateEnrollmentGradeCommand, bool>
{
    public async Task<bool> Handle(UpdateEnrollmentGradeCommand request, CancellationToken cancellationToken)
    {
        var enrollment = await enrollmentRepository.GetEnrollmentAsync(request.StudentId, request.CourseId);

        if (enrollment == null)
            throw new BusinessException(string.Format(Resource.EnrollmentNotFound, request.StudentId, request.CourseId));

        if (!Enum.TryParse<Grade>(request.NewGrade, true, out var validGrade))
        {
            throw new BusinessException(Resource.InvalidGrade);
        }

        enrollment.Grade = validGrade.ToString();

        enrollmentRepository.Update(enrollment);
        await unitOfWork.SaveChangesAsync();

        return true;
    }
}

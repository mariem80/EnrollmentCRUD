using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.DeleteStudentEnrollments;

public class DeleteStudentEnrollmentsCommandHandler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteStudentEnrollmentsCommand, bool>
{
    public async Task<bool> Handle(DeleteStudentEnrollmentsCommand request, CancellationToken cancellationToken)
    {
        var enrollments = await enrollmentRepository.GetEnrollmentsByStudentIdAsync(request.StudentId);

        if (enrollments == null || enrollments.Count == 0)
            return false; 

        enrollmentRepository.DeleteRange(enrollments); 
        await unitOfWork.SaveChangesAsync();

        return true;
    }
}

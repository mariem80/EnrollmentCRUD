using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.DeleteStudent;

public sealed class DeleteStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteStudentCommand, bool>
{
    public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetByEmailAsync(request.Email);

        if (student == null)
            return false;

        studentRepository.Delete(student);
        await unitOfWork.SaveChangesAsync();

        return true;
    }
}

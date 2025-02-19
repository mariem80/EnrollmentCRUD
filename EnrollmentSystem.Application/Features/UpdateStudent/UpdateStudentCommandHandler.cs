using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Application.Resources;
using EnrollmentSystem.Application.Services;
using EnrollmentSystem.Application.UnitOfWork;
using EnrollmentSystem.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.UpdateStudent;

public class UpdateStudentCommandHandler(IStudentRepository studentRepository, PasswordEncryptionService passwordEncryptionService, IUnitOfWork unitOfWork) : IRequestHandler<UpdateStudentCommand>
{
    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetByEmailAsync(request.Email);
        if (student == null)
            throw new BusinessException(Resource.StudentNotFound);

        if (!string.IsNullOrEmpty(request.NewName))
            student.StudentName = request.NewName;

        if (!string.IsNullOrEmpty(request.NewEmail))
            student.StudentEmail = request.NewEmail;

        if (!string.IsNullOrEmpty(request.NewPassword))
            student.StudentPassword = passwordEncryptionService.HashPassword(request.NewPassword);

        studentRepository.Update(student);
        await unitOfWork.SaveChangesAsync();
    }
}

using AutoMapper;
using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Application.Services;
using EnrollmentSystem.Application.UnitOfWork;
using EnrollmentSystem.Domain.Entities;
using EnrollmentSystem.Domain.Exceptions;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EnrollmentSystem.Application.Features.RegisterStudent;

public class RegisterStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, IUnitOfWork unitOfWork,
    PasswordEncryptionService passwordEncryptionService) : IRequestHandler<RegisterStudentCommand, bool>
{
    public async Task<bool> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
    {
        var existingStudent = await studentRepository.GetByEmailAsync(request.StudentEmail);
        if (existingStudent is not null)
        {
            throw new BusinessException("A student with this email already exists.");
        }
        var encryptedPassword = passwordEncryptionService.HashPassword(request.StudentPassword);
        var student = mapper.Map<Student>(request);
        student.StudentPassword = encryptedPassword;
        await studentRepository.AddAsync(student);
        await unitOfWork.SaveChangesAsync();
        return true;
    }
}

using AutoMapper;
using EnrollmentSystem.Application.Commands;
using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Application.UnitOfWork;
using EnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.RegisterStudent;

internal class RegisterStudentCommandHanlder(IStudentRepository studentRepository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<RegisterStudentCommand, bool>
{
    public async Task<bool> HandleAsync(RegisterStudentCommand command)
    {
        var student = mapper.Map<Student>(command);
        bool added = await studentRepository.AddAsync(student);
        if (added)
            await unitOfWork.SaveChangesAsync();
        return added;
    }
}

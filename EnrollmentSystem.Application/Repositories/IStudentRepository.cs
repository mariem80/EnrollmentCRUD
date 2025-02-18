using EnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Repositories;

public interface IStudentRepository
{
    Task<bool> AddAsync(Student student);
}

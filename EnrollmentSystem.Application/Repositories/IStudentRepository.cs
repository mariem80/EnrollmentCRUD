using EnrollmentSystem.Domain.Base;
using EnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Repositories;

public interface IStudentRepository : IBaseRepository<Student>
{
    //Task<bool> AddAsync(Student student);
    Task<Student?> GetByEmailAsync(string email);
    //Task<List<Student>> GetAllAsync();
    //Task UpdateAsync(Student student);
    //Task DeleteAsync(Student student);
}

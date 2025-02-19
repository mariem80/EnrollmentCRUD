using EnrollmentSystem.Domain.Base;
using EnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Repositories;

public interface IEnrollmentRepository : IBaseRepository<Enrollment>
{
    Task<Enrollment?> GetEnrollmentAsync(int studentId, int courseId);
    Task<List<Enrollment>> GetAllEnrollmentsAsync();
    Task<List<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId);
    void DeleteRange(List<Enrollment> enrollments);
}

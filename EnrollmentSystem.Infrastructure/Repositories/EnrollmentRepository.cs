using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Domain.Entities;
using EnrollmentSystem.Infrastructure.Data;
using EnrollmentSystem.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Infrastructure.Repositories;

public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
{

    public EnrollmentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Enrollment?> GetEnrollmentAsync(int studentId, int courseId)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.StudentID == studentId && e.CourseID == courseId);
    }
    public async Task<List<Enrollment>> GetAllEnrollmentsAsync()
    {
        return await _dbSet
            .Include(e => e.Student) 
            .Include(e => e.Course)  
            .ThenInclude(c => c.Instructor) 
            .ToListAsync();
    }

    public async Task<List<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
    {
        return await _dbSet.Where(e => e.StudentID == studentId).ToListAsync();
    }

    public void DeleteRange(List<Enrollment> enrollments)
    {
        _dbSet.RemoveRange(enrollments);
    }
}

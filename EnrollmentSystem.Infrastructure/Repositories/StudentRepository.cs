using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Domain.Entities;
using EnrollmentSystem.Infrastructure.Data;
using EnrollmentSystem.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EnrollmentSystem.Infrastructure.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext context) : base(context) {}


    //public async Task<bool> AddAsync(Student student)
    //{
    //    EntityEntry<Student> added = await _students.AddAsync(student);
    //    return added.State == EntityState.Added;
    //}
    public async Task<Student?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.StudentEmail == email);
    }

}

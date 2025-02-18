using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Domain.Entities;
using EnrollmentSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Student> _students;
    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
        _students = _context.Set<Student>();
    }
    public async Task<bool> AddAsync(Student student)
    {
        EntityEntry<Student> added = await _students.AddAsync(student);
        return added.State == EntityState.Added;
    }
}

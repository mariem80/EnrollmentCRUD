using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Application.UnitOfWork;
using EnrollmentSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IStudentRepository Students { get; }
    public IInstructorRepository Instructors { get; }
    public ICourseRepository Courses { get; }
    public IEnrollmentRepository Enrollments { get; }

    public UnitOfWork(
        ApplicationDbContext context,
        IStudentRepository studentRepository,
        IInstructorRepository instructorRepository,
        ICourseRepository courseRepository,
        IEnrollmentRepository enrollments)
    {
        _context = context;
        Students = studentRepository;
        Instructors = instructorRepository;
        Courses = courseRepository;
        Enrollments = enrollments;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}


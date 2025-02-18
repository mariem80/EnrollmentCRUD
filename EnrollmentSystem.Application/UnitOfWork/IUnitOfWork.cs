using EnrollmentSystem.Application.Repositories;

namespace EnrollmentSystem.Application.UnitOfWork;
public interface IUnitOfWork : IDisposable
{
    IStudentRepository Students { get; }
    IInstructorRepository Instructors { get; }
    ICourseRepository Courses { get; }
    IEnrollmentRepository Enrollments { get; }

    Task<int> SaveChangesAsync();
}
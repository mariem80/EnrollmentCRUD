using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Domain.Entities;
using EnrollmentSystem.Infrastructure.Data;
using EnrollmentSystem.Infrastructure.Repositories.Base;

namespace EnrollmentSystem.Infrastructure.Repositories;

public class CourseRepository :  BaseRepository<Course> , ICourseRepository
{

    public CourseRepository(ApplicationDbContext context) : base(context) { }
}

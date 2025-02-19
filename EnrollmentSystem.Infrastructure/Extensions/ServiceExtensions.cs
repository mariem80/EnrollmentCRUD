using EnrollmentSystem.Application.Features.EnrollStudents;
using EnrollmentSystem.Application.Features.RegisterStudent;
using EnrollmentSystem.Application.Features.UpdateStudent;
using EnrollmentSystem.Application.MappingProfile;
using EnrollmentSystem.Application.Repositories;
using EnrollmentSystem.Application.Services;
using EnrollmentSystem.Application.UnitOfWork;
using EnrollmentSystem.Domain.Base;
using EnrollmentSystem.Infrastructure.Repositories;
using EnrollmentSystem.Infrastructure.Repositories.Base;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EnrollmentSystem.Infrastructure.Extensions;
public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterStudentCommandHandler>());
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddScoped<IValidator<RegisterStudentCommand>, RegisterStudentCommandValidator>();
        services.AddScoped<IValidator<UpdateStudentCommand>, UpdateStudentCommandValidator>();
        services.AddScoped<IValidator<EnrollStudentsCommand>, EnrollStudentsCommandValidator>();
        services.AddSingleton<PasswordEncryptionService>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        return services;
    }
}
using AutoMapper;
using EnrollmentSystem.Application.DTOs.Enrollment.Responses;
using EnrollmentSystem.Application.DTOs.Student.Responses;
using EnrollmentSystem.Application.Features.RegisterStudent;
using EnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterStudentCommand, Student>();
        CreateMap<Student, StudentDto>();
        CreateMap<Enrollment, EnrollmentDto>()
    .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.StudentName))
    .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.CourseName))
    .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Course.Instructor.InstructorName));
    }
}

using AutoMapper;
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
        CreateMap<Student, RegisterStudentCommand>();
    }
}

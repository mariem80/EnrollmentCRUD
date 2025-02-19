using EnrollmentSystem.Application.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.EnrollStudents;

public class EnrollStudentsCommandValidator : AbstractValidator<EnrollStudentsCommand>
{
    public EnrollStudentsCommandValidator()
    {
        RuleFor(x => x.CourseId)
            .GreaterThan(0).WithMessage(Resource.CourseIdGreaterThanZero);

        RuleFor(x => x.StudentIds)
            .NotEmpty().WithMessage(Resource.AtLeastOneStudentMustBeEnrolled)
            .ForEach(studentId => studentId.GreaterThan(0).WithMessage(Resource.InvalidStudentID));
    }
}

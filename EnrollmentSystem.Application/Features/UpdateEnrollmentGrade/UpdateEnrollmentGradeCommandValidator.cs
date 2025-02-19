using EnrollmentSystem.Application.Resources;
using EnrollmentSystem.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.UpdateEnrollmentGrade;

public class UpdateEnrollmentGradeCommandValidator : AbstractValidator<UpdateEnrollmentGradeCommand>
{
    public UpdateEnrollmentGradeCommandValidator()
    {
        RuleFor(x => x.NewGrade)
            .NotEmpty().WithMessage(Resource.GradeRequired)
            .Must(grade => Enum.TryParse(typeof(Grade), grade, true, out _))
            .WithMessage(Resource.InvalidGrade);
    }
}
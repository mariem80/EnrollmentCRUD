using EnrollmentSystem.Application.Features.UpdateStudent;
using EnrollmentSystem.Application.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.UpdateStudent;

public sealed class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(x => x.NewName)
            .NotEmpty().WithMessage(Resource.StudentNameRequired)
            .MinimumLength(3).WithMessage(Resource.StudentNameMinLength)
            .MaximumLength(50).WithMessage(Resource.StudentNameMaxLength)
            .When(x => !string.IsNullOrEmpty(x.NewName));

        RuleFor(x => x.NewEmail)
            .EmailAddress().WithMessage(Resource.InvalidEmail)
            .When(x => !string.IsNullOrEmpty(x.NewEmail));

        RuleFor(x => x.NewPassword)
            .MinimumLength(6).WithMessage(Resource.PasswordMinLength)
            .Matches(@"[A-Z]").WithMessage(Resource.PasswordUppercase)
            .Matches(@"[a-z]").WithMessage(Resource.PasswordLowercase)
            .Matches(@"\d").WithMessage(Resource.PasswordDigit)
            .Matches(@"[\W_]").WithMessage(Resource.PasswordSpecialCharacter)
            .When(x => !string.IsNullOrEmpty(x.NewPassword));
    }
}

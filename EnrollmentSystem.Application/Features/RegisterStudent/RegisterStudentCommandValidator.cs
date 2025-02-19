using EnrollmentSystem.Application.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.RegisterStudent;

public sealed class RegisterStudentCommandValidator : AbstractValidator<RegisterStudentCommand>
{
    public RegisterStudentCommandValidator()
    {
        RuleFor(x => x.StudentName)
            .NotEmpty().WithMessage(Resource.StudentNameRequired)
            .MinimumLength(3).WithMessage(Resource.StudentNameMinLength)
            .MaximumLength(50).WithMessage(Resource.StudentNameMaxLength);

        RuleFor(x => x.StudentEmail)
            .NotEmpty().WithMessage(Resource.StudentEmailRequired)
            .EmailAddress().WithMessage(Resource.InvalidEmail);

        RuleFor(x => x.StudentPassword)
            .NotEmpty().WithMessage(Resource.PasswordRequired)
            .MinimumLength(6).WithMessage(Resource.PasswordMinLength)
            .Matches(@"[A-Z]").WithMessage(Resource.PasswordUppercase)
            .Matches(@"[a-z]").WithMessage(Resource.PasswordLowercase)
            .Matches(@"\d").WithMessage(Resource.PasswordDigit)
            .Matches(@"[\W_]").WithMessage(Resource.PasswordSpecialCharacter);
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Features.RegisterStudent;

internal sealed class RegisterStudentCommandValidator : AbstractValidator<RegisterStudentCommand>
{
    public RegisterStudentCommandValidator()
    {
        RuleFor(x => x.StudentName)
            .NotEmpty().WithMessage("Student name is required.")
            .MinimumLength(3).WithMessage("Student name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Student name must not exceed 50 characters.");

        RuleFor(x => x.StudentEmail)
            .NotEmpty().WithMessage("Student email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.StudentPassword)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"\d").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");
    }
}

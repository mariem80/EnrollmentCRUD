using EnrollmentSystem.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnrollmentSystem.Application.Features.RegisterStudent;

public sealed record RegisterStudentCommand(string StudentName, string StudentEmail, string StudentPassword) : ICommand<bool>;

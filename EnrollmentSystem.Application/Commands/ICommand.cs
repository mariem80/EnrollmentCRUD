using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.Commands;

public interface ICommand
{
}

public interface ICommand<T> : ICommand
{
}
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Commands.DesactivateEmployee
{
    public sealed class DeactivateEmployeeCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
    }
}

using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Commands.RegisterEmployee
{
    public sealed class RegisterEmployeeCommand : IRequest<Result<Guid>>
    {
        public string IdentificationNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Area { get; set; } = null!;
    }
}

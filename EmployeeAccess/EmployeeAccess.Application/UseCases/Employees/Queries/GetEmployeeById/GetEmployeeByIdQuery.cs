using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeeById;

public sealed class GetEmployeeByIdQuery : IRequest<Result<EmployeeDetailsDTO>>
{
    public Guid Id { get; set; }
}

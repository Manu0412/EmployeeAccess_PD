using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessPoints.Commands.RegisterAccessPoint;

public sealed class RegisterAccessPointCommand : IRequest<Result<Guid>>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}

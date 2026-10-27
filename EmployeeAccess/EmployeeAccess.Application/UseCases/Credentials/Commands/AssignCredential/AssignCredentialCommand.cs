using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Credentials.Commands.AssignCredential;

public sealed class AssignCredentialCommand : IRequest<Result<Guid>>
{
    public Guid EmployeeId { get; set; }
    public string Code { get; set; } = null!;
}

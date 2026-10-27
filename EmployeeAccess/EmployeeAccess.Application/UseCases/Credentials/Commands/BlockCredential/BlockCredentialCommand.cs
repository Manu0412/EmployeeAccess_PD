using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Credentials.Commands.BlockCredential;

public sealed class BlockCredentialCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}

using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Credentials.Queries.GetCredentialStatus;

public sealed class GetCredentialStatusQuery : IRequest<Result<CredentialStatusDTO>>
{
    public string Code { get; set; } = null!;
}

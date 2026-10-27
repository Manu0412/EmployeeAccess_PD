using EmployeeAccess.Domain.Entities.Credentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Credentials.Queries.GetCredentialStatus;

public sealed class CredentialStatusDTO
{
    public Guid Id { get; init; }
    public string Code { get; init; } = null!;
    public Guid EmployeeId { get; init; }
    public CredentialStatus Status { get; init; }
    public bool CanBeUsed { get; init; }
    public DateTime IssuedAt { get; init; }
}

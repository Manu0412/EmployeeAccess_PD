using EmployeeAccess.Domain.Entities.Credentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Credentials.Queries.GetCredentialStatus;

internal static class MapperExtensions
{
    public static CredentialStatusDTO ToStatusDTO(this Credential credential)
    {
        return new CredentialStatusDTO
        {
            Id = credential.Id,
            Code = credential.Code,
            EmployeeId = credential.EmployeeId,
            Status = credential.Status,
            CanBeUsed = credential.CanBeUsed,
            IssuedAt = credential.IssuedAt
        };
    }
}

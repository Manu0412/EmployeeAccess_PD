using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.Exceptions;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.Credentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Credentials.Queries.GetCredentialStatus;

public sealed class GetCredentialStatusUseCase :
    BaseHandler, IRequestHandler<GetCredentialStatusQuery, Result<CredentialStatusDTO>>
{
    private readonly ICredentialsRepository _credentialsRepository;

    public GetCredentialStatusUseCase(ICredentialsRepository credentialsRepository)
    {
        _credentialsRepository = credentialsRepository;
    }

    public async Task<Result<CredentialStatusDTO>> Handle(GetCredentialStatusQuery query)
    {
        return await ExecuteAsync(async () =>
        {
            Credential? credential = await _credentialsRepository.GetByCodeAsync(query.Code.Trim());

            if (credential is null)
            {
                throw new NotFoundException($"No existe una credencial con el código {query.Code}.");
            }

            return credential.ToStatusDTO();
        });
    }
}

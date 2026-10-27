using EmployeeAccess.Domain.Entities.Credentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.Contracts.Repositories
{
    public interface ICredentialsRepository : IRepository<Credential>
    {
        Task<Credential?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken = default);
    }
}

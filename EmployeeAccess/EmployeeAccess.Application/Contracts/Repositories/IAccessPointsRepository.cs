using EmployeeAccess.Domain.Entities.AccessControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.Contracts.Repositories
{
    public interface IAccessPointsRepository : IRepository<AccessPoint>
    {
        Task<IEnumerable<AccessPoint>> GetFilteredListAsync(bool? isEnabled,
            CancellationToken cancellationToken = default);
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}

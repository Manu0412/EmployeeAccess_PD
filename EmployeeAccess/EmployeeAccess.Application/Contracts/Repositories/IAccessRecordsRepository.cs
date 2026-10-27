using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Domain.Entities.AccessControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.Contracts.Repositories
{
    public interface IAccessRecordsRepository : IRepository<AccessRecord>
    {
        Task<PaginationResponse<AccessRecord>> GetPagedListAsync(
            PaginationRequest request, Guid? employeeId, Guid? accessPointId,
            DateTime? from, DateTime? to, AccessResult? result,
            CancellationToken cancellationToken = default);
    }
}

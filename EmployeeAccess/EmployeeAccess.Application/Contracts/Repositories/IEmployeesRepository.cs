using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.Contracts.Repositories
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
        Task<PaginationResponse<Employee>> GetPagedListAsync(
            PaginationRequest request, string? area, EmployeeStatus? status,
            CancellationToken cancellationToken = default);

        Task<bool> ExistsByIdentificationAsync(string identificationNumber,
            CancellationToken cancellationToken = default);
    }
}

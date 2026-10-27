using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Domain.Entities.Employees;
using EmployeeAccess.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Repositories
{
    public class EmployeesRepository : Repository<Employee>, IEmployeesRepository
    {
        private readonly DataContext _context;

        public EmployeesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<Employee>> GetPagedListAsync(
            PaginationRequest request, string? area, EmployeeStatus? status,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Employee> query = _context.Set<Employee>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(area))
            {
                query = query.Where(e => e.Area == area);
            }

            if (status.HasValue)
            {
                query = query.Where(e => e.Status == status);
            }

            query = query.OrderBy(e => e.LastName).ThenBy(e => e.FirstName);

            return await query.ToPagedListAsync(request, cancellationToken);
        }

        public async Task<bool> ExistsByIdentificationAsync(
            string identificationNumber, CancellationToken cancellationToken = default)
        {
            string normalized = identificationNumber.Trim();

            return await _context.Set<Employee>().AnyAsync(e => e.IdentificationNumber == normalized, cancellationToken);
        }
    }
}

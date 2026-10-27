using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Domain.Entities.AccessControl;
using EmployeeAccess.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Repositories
{
    public class AccessRecordsRepository : Repository<AccessRecord>, IAccessRecordsRepository
    {
        private readonly DataContext _context;

        public AccessRecordsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<AccessRecord>> GetPagedListAsync(PaginationRequest request, Guid? employeeId, Guid? accessPointId,
            DateTime? from, DateTime? to, AccessResult? result,CancellationToken cancellationToken = default)
        {
            IQueryable<AccessRecord> query = _context.Set<AccessRecord>()
                                                     .Include(r => r.AccessPoint)
                                                     .AsQueryable();

            if (employeeId.HasValue)
            {
                query = query.Where(r => r.EmployeeId == employeeId);
            }

            if (accessPointId.HasValue)
            {
                query = query.Where(r => r.AccessPointId == accessPointId);
            }

            if (from.HasValue)
            {
                query = query.Where(r => r.OccurredAt >= from.Value);
            }

            if (to.HasValue)
            {
                query = query.Where(r => r.OccurredAt <= to.Value);
            }

            if (result.HasValue)
            {
                query = query.Where(r => r.Result == result);
            }

            query = query.OrderByDescending(r => r.OccurredAt);

            return await query.ToPagedListAsync(request, cancellationToken);
        }
    }
}

using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Domain.Entities.AccessControl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Repositories
{
    public class AccessPointsRepository : Repository<AccessPoint>, IAccessPointsRepository
    {
        private readonly DataContext _context;

        public AccessPointsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccessPoint>> GetFilteredListAsync(
            bool? isEnabled, CancellationToken cancellationToken = default)
        {
            IQueryable<AccessPoint> query = _context.Set<AccessPoint>().AsQueryable();

            if (isEnabled.HasValue)
            {
                query = query.Where(a => a.IsEnabled == isEnabled);
            }

            return await query.OrderBy(a => a.Name).ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Set<AccessPoint>().AnyAsync(a => a.Name == name, cancellationToken);
        }
    }
}

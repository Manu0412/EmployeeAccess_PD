using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Domain.Entities.Credentials;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Repositories
{
    public class CredentialsRepository : Repository<Credential>, ICredentialsRepository
    {
        private readonly DataContext _context;

        public CredentialsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Credential?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Credential>()
                                 .Include(c => c.Employee)
                                 .FirstOrDefaultAsync(c => c.Code == code, cancellationToken);
        }

        public async Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Credential>().AnyAsync(c => c.Code == code, cancellationToken);
        }
    }
}

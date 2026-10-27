using EmployeeAccess.Domain.Entities.AccessControl;
using EmployeeAccess.Domain.Entities.Credentials;
using EmployeeAccess.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Credential> Credentials { get; set; } = null!;
        public DbSet<AccessPoint> AccessPoints { get; set; } = null!;
        public DbSet<AccessRecord> AccessRecords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}

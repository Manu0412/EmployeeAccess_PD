using EmployeeAccess.Domain.Common.ValueObjects;
using EmployeeAccess.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Seeds
{
    public class EmployeeSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public EmployeeSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 2;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Employees.AnyAsync(cancellationToken))
            {
                return;
            }

            List<Employee> employees =
            [
                new Employee("1001234567", "Laura", "Gómez", Email.Create("laura.gomez@example.com"), "Analista de logística", "Operaciones"),
                new Employee("1002345678", "Carlos", "Restrepo", Email.Create("carlos.restrepo@example.com"), "Jefe de bodega", "Almacenamiento"),
                new Employee("1003456789", "Marta", "Ruiz", Email.Create("marta.ruiz@example.com"), "Guarda de seguridad", "Seguridad"),
             ];

            await _context.Employees.AddRangeAsync(employees, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

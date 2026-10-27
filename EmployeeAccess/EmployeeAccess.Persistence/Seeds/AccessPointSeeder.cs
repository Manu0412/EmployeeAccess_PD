using EmployeeAccess.Domain.Entities.AccessControl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Seeds
{
    public class AccessPointSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public AccessPointSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 1;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.AccessPoints.AnyAsync(cancellationToken))
            {
                return;
            }

            List<AccessPoint> accessPoints =
            [
                new AccessPoint("Recepción", "Entrada principal de la sede"),
                new AccessPoint("Parqueadero", "Acceso vehicular de empleados"),
                new AccessPoint("Bodega", "Área de almacenamiento logístico"),
                new AccessPoint("Área restringida", "Zona de acceso limitado"),
            ];

            await _context.AccessPoints.AddRangeAsync(accessPoints, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

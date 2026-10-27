using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Seeds
{
    /// <summary>
    /// Contrato de un seeder de infraestructura.
    /// Cada implementación carga un conjunto de datos iniciales
    public interface IDataSeeder
    {
        /// <summary>
        ///  Orden de ejecución; Menor = Primero
        /// </summary>
        int Order { get; }

        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}

using EmployeeAccess.Application.Contracts.Persistence;
using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Persistence.Repositories;
using EmployeeAccess.Persistence.Seeds;
using EmployeeAccess.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence
{
    public static class PersistenceServicesRegistry
    {
        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyConnection"));
            });

            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();

            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<ICredentialsRepository, CredentialsRepository>();
            services.AddScoped<IAccessPointsRepository, AccessPointsRepository>();
            services.AddScoped<IAccessRecordsRepository, AccessRecordsRepository>();

            // Seeders
            services.AddScoped<IDataSeeder, AccessPointSeeder>();
            services.AddScoped<IDataSeeder, EmployeeSeeder>();

            return services;
        }
    }
}

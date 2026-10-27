using EmployeeAccess.Application.UseCases.AccessPoints.Commands.RegisterAccessPoint;
using EmployeeAccess.Application.UseCases.AccessPoints.Queries.GetAccessPointsList;
using EmployeeAccess.Application.UseCases.AccessRecords.Commands.RegisterAccess;
using EmployeeAccess.Application.UseCases.AccessRecords.Queries.GetAccessHistory;
using EmployeeAccess.Application.UseCases.Credentials.Commands.AssignCredential;
using EmployeeAccess.Application.UseCases.Credentials.Commands.BlockCredential;
using EmployeeAccess.Application.UseCases.Credentials.Commands.RevokeCredential;
using EmployeeAccess.Application.UseCases.Credentials.Queries.GetCredentialStatus;
using EmployeeAccess.Application.UseCases.Employees.Commands.DeactivateEmployee;
using EmployeeAccess.Application.UseCases.Employees.Commands.DesactivateEmployee;
using EmployeeAccess.Application.UseCases.Employees.Commands.RegisterEmployee;
using EmployeeAccess.Application.UseCases.Employees.Commands.UpdateEmployee;
using EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeeById;
using EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeesList;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Application.Utilities.Results;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace EmployeeAccess.Application
{
    public static class ApplicationServicesRegistry
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediator, SimpleMediator>();

            // Employees
            services.AddScoped<IRequestHandler<RegisterEmployeeCommand, Result<Guid>>, RegisterEmployeeUseCase>();
            services.AddScoped<IRequestHandler<UpdateEmployeeCommand, Result<Guid>>, UpdateEmployeeUseCase>();
            services.AddScoped<IRequestHandler<DeactivateEmployeeCommand, Result<Guid>>, DeactivateEmployeeUseCase>();
            services.AddScoped<IRequestHandler<GetEmployeesListQuery, Result<PaginationResponse<EmployeeListItemDTO>>>, GetEmployeesListUseCase>();
            services.AddScoped<IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeDetailsDTO>>, GetEmployeeByIdUseCase>();

            // Credentials
            services.AddScoped<IRequestHandler<AssignCredentialCommand, Result<Guid>>, AssignCredentialUseCase>();
            services.AddScoped<IRequestHandler<BlockCredentialCommand, Result<Guid>>, BlockCredentialUseCase>();
            services.AddScoped<IRequestHandler<RevokeCredentialCommand, Result<Guid>>, RevokeCredentialUseCase>();
            services.AddScoped<IRequestHandler<GetCredentialStatusQuery, Result<CredentialStatusDTO>>, GetCredentialStatusUseCase>();

            // Access points
            services.AddScoped<IRequestHandler<RegisterAccessPointCommand, Result<Guid>>, RegisterAccessPointUseCase>();
            services.AddScoped<IRequestHandler<GetAccessPointsListQuery, Result<List<AccessPointListItemDTO>>>, GetAccessPointsListUseCase>();

            // Access records
            services.AddScoped<IRequestHandler<RegisterAccessCommand, Result<RegisterAccessResultDTO>>, RegisterAccessUseCase>();
            services.AddScoped<IRequestHandler<GetAccessHistoryQuery, Result<PaginationResponse<AccessRecordListItemDTO>>>, GetAccessHistoryUseCase>();

            // Validations
            services.AddValidatorsFromAssemblyContaining<RegisterEmployeeCommandValidator>();

            return services;
        }
    }
}

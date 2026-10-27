using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.Exceptions;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeeById;

public sealed class GetEmployeeByIdUseCase :
    BaseHandler, IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeDetailsDTO>>
{
    private readonly IEmployeesRepository _employeesRepository;

    public GetEmployeeByIdUseCase(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<Result<EmployeeDetailsDTO>> Handle(GetEmployeeByIdQuery query)
    {
        return await ExecuteAsync(async () =>
        {
            Employee? employee = await _employeesRepository.GetByIdAsync(query.Id);

            if (employee is null)
            {
                throw new NotFoundException($"No existe un empleado con ID {query.Id}.");
            }

            return employee.ToDetailsDTO();
        });
    }
}

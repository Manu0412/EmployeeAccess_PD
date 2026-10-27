using EmployeeAccess.Application.Contracts.Persistence;
using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.Exceptions;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Common.ValueObjects;
using EmployeeAccess.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Commands.UpdateEmployee;

public sealed class UpdateEmployeeUseCase :
    BaseHandler, IRequestHandler<UpdateEmployeeCommand, Result<Guid>>
{
    private readonly IEmployeesRepository _employeesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeUseCase(IEmployeesRepository employeesRepository, IUnitOfWork unitOfWork)
    {
        _employeesRepository = employeesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateEmployeeCommand command)
    {
        return await ExecuteAsync(async () =>
        {
            Employee? employee = await _employeesRepository.GetByIdAsync(command.Id);

            if (employee is null)
            {
                throw new NotFoundException($"No existe un empleado con ID {command.Id}.");
            }

            employee.Update(
                command.FirstName,
                command.LastName,
                Email.Create(command.Email),
                command.Position,
                command.Area);

            await _employeesRepository.UpdateAsync(employee);
            await _unitOfWork.CommitAsync();

            return employee.Id;
        });
    }
}

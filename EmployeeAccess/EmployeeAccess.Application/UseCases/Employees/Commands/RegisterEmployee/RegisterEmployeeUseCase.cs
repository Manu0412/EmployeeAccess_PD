using EmployeeAccess.Application.Contracts.Persistence;
using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Common.ValueObjects;
using EmployeeAccess.Domain.Entities.Employees;
using EmployeeAccess.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Commands.RegisterEmployee
{
    public sealed class RegisterEmployeeUseCase :
        BaseHandler, IRequestHandler<RegisterEmployeeCommand, Result<Guid>>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterEmployeeUseCase(IEmployeesRepository employeesRepository, IUnitOfWork unitOfWork)
        {
            _employeesRepository = employeesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(RegisterEmployeeCommand command)
        {
            return await ExecuteAsync(async () =>
            {
                bool exists = await _employeesRepository.ExistsByIdentificationAsync(command.IdentificationNumber);

                if (exists)
                {
                    throw new BusinessRuleException("Ya existe un empleado con esa identificación.");
                }

                Employee employee = new(
                    command.IdentificationNumber,
                    command.FirstName,
                    command.LastName,
                    Email.Create(command.Email),
                    command.Position,
                    command.Area);

                await _employeesRepository.CreateAsync(employee);
                await _unitOfWork.CommitAsync();

                return employee.Id;
            });
        }
    }
}

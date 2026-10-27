using EmployeeAccess.Application.Contracts.Persistence;
using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.Exceptions;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.Credentials;
using EmployeeAccess.Domain.Entities.Employees;
using EmployeeAccess.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Credentials.Commands.AssignCredential;

public sealed class AssignCredentialUseCase :
    BaseHandler, IRequestHandler<AssignCredentialCommand, Result<Guid>>
{
    private readonly IEmployeesRepository _employeesRepository;
    private readonly ICredentialsRepository _credentialsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssignCredentialUseCase(IEmployeesRepository employeesRepository,
                                   ICredentialsRepository credentialsRepository,
                                   IUnitOfWork unitOfWork)
    {
        _employeesRepository = employeesRepository;
        _credentialsRepository = credentialsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(AssignCredentialCommand command)
    {
        return await ExecuteAsync(async () =>
        {
            Employee? employee = await _employeesRepository.GetByIdAsync(command.EmployeeId);

            if (employee is null)
            {
                throw new NotFoundException($"No existe un empleado con ID {command.EmployeeId}.");
            }

            if (!employee.IsActive)
            {
                throw new BusinessRuleException("No se puede asignar una credencial a un empleado inactivo.");
            }

            string code = command.Code.Trim();

            if (await _credentialsRepository.ExistsByCodeAsync(code))
            {
                throw new BusinessRuleException("Ya existe una credencial con ese código.");
            }

            Credential credential = new(code, employee.Id);

            await _credentialsRepository.CreateAsync(credential);
            await _unitOfWork.CommitAsync();

            return credential.Id;
        });
    }
}

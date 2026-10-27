using EmployeeAccess.Application.Contracts.Persistence;
using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.AccessControl;
using EmployeeAccess.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessPoints.Commands.RegisterAccessPoint;

public sealed class RegisterAccessPointUseCase :
    BaseHandler, IRequestHandler<RegisterAccessPointCommand, Result<Guid>>
{
    private readonly IAccessPointsRepository _accessPointsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterAccessPointUseCase(IAccessPointsRepository accessPointsRepository, IUnitOfWork unitOfWork)
    {
        _accessPointsRepository = accessPointsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterAccessPointCommand command)
    {
        return await ExecuteAsync(async () =>
        {
            if (await _accessPointsRepository.ExistsByNameAsync(command.Name.Trim()))
            {
                throw new BusinessRuleException("Ya existe un punto de acceso con ese nombre.");
            }

            AccessPoint accessPoint = new(command.Name, command.Description);

            await _accessPointsRepository.CreateAsync(accessPoint);
            await _unitOfWork.CommitAsync();

            return accessPoint.Id;
        });
    }
}

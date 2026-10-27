using EmployeeAccess.Application.Contracts.Persistence;
using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.Exceptions;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.AccessControl;
using EmployeeAccess.Domain.Entities.Credentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessRecords.Commands.RegisterAccess
{
    public sealed class RegisterAccessUseCase :
        BaseHandler, IRequestHandler<RegisterAccessCommand, Result<RegisterAccessResultDTO>>
    {
        private readonly IAccessPointsRepository _accessPointsRepository;
        private readonly ICredentialsRepository _credentialsRepository;
        private readonly IAccessRecordsRepository _accessRecordsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterAccessUseCase(IAccessPointsRepository accessPointsRepository,
                                     ICredentialsRepository credentialsRepository,
                                     IAccessRecordsRepository accessRecordsRepository,
                                     IUnitOfWork unitOfWork)
        {
            _accessPointsRepository = accessPointsRepository;
            _credentialsRepository = credentialsRepository;
            _accessRecordsRepository = accessRecordsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<RegisterAccessResultDTO>> Handle(RegisterAccessCommand command)
        {
            return await ExecuteAsync(async () =>
            {
                AccessPoint? accessPoint = await _accessPointsRepository.GetByIdAsync(command.AccessPointId);

                if (accessPoint is null)
                {
                    throw new NotFoundException($"No existe un punto de acceso con ID {command.AccessPointId}.");
                }

                string code = command.CredentialCode.Trim();
                Credential? credential = await _credentialsRepository.GetByCodeAsync(code);

                string? rejectionReason = GetRejectionReason(accessPoint, credential);

                AccessRecord record = rejectionReason is null
                    ? AccessRecord.Authorized(code, credential!.EmployeeId, accessPoint.Id, command.Movement)
                    : AccessRecord.Rejected(code, credential?.EmployeeId, accessPoint.Id, command.Movement, rejectionReason);

                await _accessRecordsRepository.CreateAsync(record);
                await _unitOfWork.CommitAsync();

                return new RegisterAccessResultDTO
                {
                    AccessRecordId = record.Id,
                    Result = record.Result,
                    RejectionReason = record.RejectionReason,
                    OccurredAt = record.OccurredAt
                };
            });
        }

        private static string? GetRejectionReason(AccessPoint accessPoint, Credential? credential)
        {
            if (!accessPoint.IsEnabled)
                return "El punto de acceso está deshabilitado.";

            if (credential is null)
                return "La credencial no existe.";

            if (credential.Status == CredentialStatus.Blocked)
                return "La credencial está bloqueada.";

            if (credential.Status == CredentialStatus.Revoked)
                return "La credencial fue revocada.";

            if (!credential.Employee.IsActive)
                return "El empleado se encuentra inactivo.";

            return null;
        }
    }
}

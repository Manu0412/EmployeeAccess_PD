using EmployeeAccess.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Domain.Entities.AccessControl
{
    public sealed class AccessRecord
    {
        public Guid Id { get; private set; }
        public string CredentialCode { get; private set; } = null!;
        public Guid? EmployeeId { get; private set; }
        public Guid AccessPointId { get; private set; }
        public AccessPoint AccessPoint { get; private set; } = null!;
        public MovementType Movement { get; private set; }
        public AccessResult Result { get; private set; }
        public string? RejectionReason { get; private set; }
        public DateTime OccurredAt { get; private set; }

        private AccessRecord() { }

        private AccessRecord(string credentialCode, Guid? employeeId, Guid accessPointId, MovementType movement, AccessResult result, string? reason)
        {
            Id = Guid.CreateVersion7();
            CredentialCode = credentialCode;
            EmployeeId = employeeId;
            AccessPointId = accessPointId;
            Movement = movement;
            Result = result;
            RejectionReason = reason;
            OccurredAt = DateTime.UtcNow;
        }

        public static AccessRecord Authorized(string credentialCode, Guid employeeId, Guid accessPointId, MovementType movement)
            => new(credentialCode, employeeId, accessPointId, movement, AccessResult.Authorized, null);

        public static AccessRecord Rejected(string credentialCode, Guid? employeeId, Guid accessPointId, MovementType movement, string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new BusinessRuleException("El motivo del rechazo es requerido.");
            return new(credentialCode, employeeId, accessPointId, movement, AccessResult.Rejected, reason);
        }
    }
}

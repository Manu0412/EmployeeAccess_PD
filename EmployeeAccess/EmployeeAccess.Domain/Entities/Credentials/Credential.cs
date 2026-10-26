using EmployeeAccess.Domain.Entities.Employees;
using EmployeeAccess.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Domain.Entities.Credentials
{
    public sealed class Credential
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; } = null!;
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;
        public CredentialStatus Status { get; private set; }
        public DateTime IssuedAt { get; private set; }

        public bool CanBeUsed => Status == CredentialStatus.Active;

        private Credential() { }

        public Credential(string code, Guid employeeId)
        {
            ApplyCodeRules(code);
            ApplyEmployeeIdRules(employeeId);

            Id = Guid.CreateVersion7();
            Code = code.Trim();
            EmployeeId = employeeId;
            Status = CredentialStatus.Active;
            IssuedAt = DateTime.UtcNow;
        }

        public void Block()
        {
            if (Status == CredentialStatus.Revoked)
                throw new BusinessRuleException("Una credencial revocada no puede bloquearse.");
            if (Status == CredentialStatus.Blocked)
                throw new BusinessRuleException("La credencial ya está bloqueada.");
            Status = CredentialStatus.Blocked;
        }

        public void Revoke()
        {
            if (Status == CredentialStatus.Revoked)
                throw new BusinessRuleException("La credencial ya fue revocada.");
            Status = CredentialStatus.Revoked;
        }

        private static void ApplyCodeRules(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new BusinessRuleException("El código de la credencial es requerido.");

            if (code.Trim().Length < 4 || code.Trim().Length > 64)
                throw new BusinessRuleException("El código de la credencial debe tener entre 4 y 64 caracteres.");
        }

        private static void ApplyEmployeeIdRules(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
                throw new BusinessRuleException("El empleado es requerido.");
        }
    }
}

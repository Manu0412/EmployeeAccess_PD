using EmployeeAccess.Domain.Common.ValueObjects;
using EmployeeAccess.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Domain.Entities.Employees
{
    public sealed class Employee
    {
        public Guid Id { get; private set; }
        public string IdentificationNumber { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public string Position { get; private set; } = null!;
        public string Area { get; private set; } = null!;
        public EmployeeStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public bool IsActive => Status == EmployeeStatus.Active;

        private Employee() { }

        public Employee(string identificationNumber, string firstName, string lastName, Email email, string position, string area)
        {
            ApplyIdentificationRules(identificationNumber);
            ApplyNameRules(firstName, "nombres");
            ApplyNameRules(lastName, "apellidos");
            ApplyEmailRules(email);
            ApplyTextRules(position, "cargo");
            ApplyTextRules(area, "área");

            Id = Guid.CreateVersion7();
            IdentificationNumber = identificationNumber.Trim();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email;
            Position = position.Trim();
            Area = area.Trim();
            Status = EmployeeStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string firstName, string lastName, Email email, string position, string area)
        {
            ApplyNameRules(firstName, "nombres");
            ApplyNameRules(lastName, "apellidos");
            ApplyEmailRules(email);
            ApplyTextRules(position, "cargo");
            ApplyTextRules(area, "área");

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email;
            Position = position.Trim();
            Area = area.Trim();
        }

        public void Deactivate()
        {
            if (Status == EmployeeStatus.Inactive)
                throw new BusinessRuleException("El empleado ya se encuentra inactivo.");
            Status = EmployeeStatus.Inactive;
        }

        private static void ApplyIdentificationRules(string identificationNumber)
        {
            if (string.IsNullOrWhiteSpace(identificationNumber))
                throw new BusinessRuleException("La identificación es requerida.");

            if (identificationNumber.Trim().Length < 5 || identificationNumber.Trim().Length > 20)
                throw new BusinessRuleException("La identificación debe tener entre 5 y 20 caracteres.");
        }

        private static void ApplyNameRules(string name, string field)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException($"El campo {field} es requerido.");

            if (name.Trim().Length < 2 || name.Trim().Length > 64)
                throw new BusinessRuleException($"El campo {field} debe tener entre 2 y 64 caracteres.");
        }

        private static void ApplyEmailRules(Email email)
        {
            if (email is null)
                throw new BusinessRuleException("El correo electrónico es requerido.");
        }

        private static void ApplyTextRules(string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleException($"El campo {field} es requerido.");

            if (value.Trim().Length > 128)
                throw new BusinessRuleException($"El campo {field} debe tener máximo 128 caracteres.");
        }
    }
}

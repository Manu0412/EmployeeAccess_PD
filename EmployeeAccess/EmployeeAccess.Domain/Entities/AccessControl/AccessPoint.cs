using EmployeeAccess.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Domain.Entities.AccessControl
{
    public sealed class AccessPoint
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public bool IsEnabled { get; private set; }

        private AccessPoint() { }

        public AccessPoint(string name, string? description = null)
        {
            ApplyNameRules(name);
            ApplyDescriptionRules(description);

            Id = Guid.CreateVersion7();
            Name = name.Trim();
            Description = description?.Trim();
            IsEnabled = true;
        }

        public void Enable() { IsEnabled = true; }
        public void Disable() { IsEnabled = false; }


        private static void ApplyNameRules(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException("El nombre del punto de acceso es requerido.");

            if (name.Trim().Length < 3 || name.Trim().Length > 64)
                throw new BusinessRuleException("El nombre del punto de acceso debe tener entre 3 y 64 caracteres.");
        }

        private static void ApplyDescriptionRules(string? description)
        {
            if (description is not null && description.Trim().Length > 512)
                throw new BusinessRuleException("La descripción debe tener máximo 512 caracteres.");
        }
    }
}

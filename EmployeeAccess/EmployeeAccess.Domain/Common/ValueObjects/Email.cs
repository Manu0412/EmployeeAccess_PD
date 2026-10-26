using EmployeeAccess.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Domain.Common.ValueObjects
{
    public sealed class Email
    {
        public string Value { get; private set; } = null!;

        private Email() { }
        private Email(string value) { Value = value; }

        public static Email Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleException("El correo electrónico es requerido.");

            string email = value.Trim().ToLowerInvariant();

            if (email.Length > 256 || !email.Contains('@') || !email.Contains('.'))
                throw new BusinessRuleException("El correo electrónico no es válido.");

            return new Email(email);
        }
    }
}

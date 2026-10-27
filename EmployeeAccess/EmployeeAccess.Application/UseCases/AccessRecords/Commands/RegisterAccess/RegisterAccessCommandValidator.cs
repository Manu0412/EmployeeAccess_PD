using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessRecords.Commands.RegisterAccess
{
    public sealed class RegisterAccessCommandValidator : AbstractValidator<RegisterAccessCommand>
    {
        public RegisterAccessCommandValidator()
        {
            RuleFor(c => c.CredentialCode).NotEmpty().WithMessage("El código de la credencial es requerido.")
                .MaximumLength(64).WithMessage("El código de la credencial no debe exceder los 64 caracteres.");

            RuleFor(c => c.AccessPointId).NotEmpty().WithMessage("El punto de acceso es requerido.");

            RuleFor(c => c.Movement).IsInEnum().WithMessage("El tipo de movimiento no es válido.");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Credentials.Commands.AssignCredential;

public sealed class AssignCredentialCommandValidator : AbstractValidator<AssignCredentialCommand>
{
    public AssignCredentialCommandValidator()
    {
        RuleFor(c => c.EmployeeId).NotEmpty().WithMessage("El empleado es requerido.");

        RuleFor(c => c.Code).NotEmpty().WithMessage("El código de la credencial es requerido.")
            .MinimumLength(4).WithMessage("El código debe tener al menos 4 caracteres.")
            .MaximumLength(64).WithMessage("El código no debe exceder los 64 caracteres.");
    }
}

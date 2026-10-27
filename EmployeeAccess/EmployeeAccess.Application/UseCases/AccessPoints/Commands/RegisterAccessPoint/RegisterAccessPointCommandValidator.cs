using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessPoints.Commands.RegisterAccessPoint;

public sealed class RegisterAccessPointCommandValidator : AbstractValidator<RegisterAccessPointCommand>
{
    public RegisterAccessPointCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("El nombre del punto de acceso es requerido.")
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres.")
            .MaximumLength(64).WithMessage("El nombre no debe exceder los 64 caracteres.");

        RuleFor(c => c.Description).MaximumLength(512)
            .WithMessage("La descripción no debe exceder los 512 caracteres.")
            .When(c => c.Description is not null);
    }
}

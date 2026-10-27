using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Commands.RegisterEmployee
{
    public sealed class RegisterEmployeeCommandValidator : AbstractValidator<RegisterEmployeeCommand>
    {
        public RegisterEmployeeCommandValidator()
        {
            RuleFor(c => c.IdentificationNumber).NotEmpty().WithMessage("La identificación es requerida.")
                .MinimumLength(5).WithMessage("La identificación debe tener al menos 5 caracteres.")
                .MaximumLength(20).WithMessage("La identificación no debe exceder los 20 caracteres.");

            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Los nombres son requeridos.")
                .MaximumLength(64).WithMessage("Los nombres no deben exceder los 64 caracteres.");

            RuleFor(c => c.LastName).NotEmpty().WithMessage("Los apellidos son requeridos.")
                .MaximumLength(64).WithMessage("Los apellidos no deben exceder los 64 caracteres.");

            RuleFor(c => c.Email).NotEmpty().WithMessage("El correo es requerido.")
                .EmailAddress().WithMessage("El correo no es válido.")
                .MaximumLength(256).WithMessage("El correo no debe exceder los 256 caracteres.");

            RuleFor(c => c.Position).NotEmpty().WithMessage("El cargo es requerido.")
                .MaximumLength(128).WithMessage("El cargo no debe exceder los 128 caracteres.");

            RuleFor(c => c.Area).NotEmpty().WithMessage("El área es requerida.")
                .MaximumLength(128).WithMessage("El área no debe exceder los 128 caracteres.");
        }
    }
}

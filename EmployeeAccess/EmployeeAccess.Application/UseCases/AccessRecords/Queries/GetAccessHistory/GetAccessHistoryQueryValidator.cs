using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessRecords.Queries.GetAccessHistory
{
    public sealed class GetAccessHistoryQueryValidator : AbstractValidator<GetAccessHistoryQuery>
    {
        public GetAccessHistoryQueryValidator()
        {
            RuleFor(q => q.To)
                .Must((query, to) => to!.Value >= query.From!.Value)
                .When(q => q.From.HasValue && q.To.HasValue)
                .WithMessage("La fecha final debe ser mayor o igual a la fecha inicial.");

            RuleFor(q => q.Outcome)
                .IsInEnum()
                .When(q => q.Outcome.HasValue)
                .WithMessage("El resultado de validación no es válido.");
        }
    }
}

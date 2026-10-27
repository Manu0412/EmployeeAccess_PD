using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.AccessControl;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessRecords.Commands.RegisterAccess
{
    public sealed class RegisterAccessCommand : IRequest<Result<RegisterAccessResultDTO>>
    {
        public string CredentialCode { get; set; } = null!;
        public Guid AccessPointId { get; set; }
        public MovementType Movement { get; set; }
    }
    
}

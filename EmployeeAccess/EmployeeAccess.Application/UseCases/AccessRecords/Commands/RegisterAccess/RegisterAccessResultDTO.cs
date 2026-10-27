using EmployeeAccess.Domain.Entities.AccessControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessRecords.Commands.RegisterAccess
{
    public sealed class RegisterAccessResultDTO
    {
        public Guid AccessRecordId { get; init; }
        public AccessResult Result { get; init; }
        public string? RejectionReason { get; init; }
        public DateTime OccurredAt { get; init; }
    }
}

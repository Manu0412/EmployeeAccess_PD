using EmployeeAccess.Domain.Entities.AccessControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessRecords.Queries.GetAccessHistory
{
    public sealed class AccessRecordListItemDTO
    {
        public Guid Id { get; init; }
        public string CredentialCode { get; init; } = null!;
        public Guid? EmployeeId { get; init; }
        public Guid AccessPointId { get; init; }
        public string AccessPointName { get; init; } = null!;
        public MovementType Movement { get; init; }
        public AccessResult Result { get; init; }
        public string? RejectionReason { get; init; }
        public DateTime OccurredAt { get; init; }
    }
}

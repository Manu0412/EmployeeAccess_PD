using EmployeeAccess.Domain.Entities.AccessControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessRecords.Queries.GetAccessHistory
{
    internal static class MapperExtensions
    {
        public static AccessRecordListItemDTO ToListItemDTO(this AccessRecord record)
        {
            return new AccessRecordListItemDTO
            {
                Id = record.Id,
                CredentialCode = record.CredentialCode,
                EmployeeId = record.EmployeeId,
                AccessPointId = record.AccessPointId,
                AccessPointName = record.AccessPoint.Name,
                Movement = record.Movement,
                Result = record.Result,
                RejectionReason = record.RejectionReason,
                OccurredAt = record.OccurredAt
            };
        }
    }
}

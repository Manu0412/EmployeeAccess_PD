using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.AccessControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessRecords.Queries.GetAccessHistory
{
    public sealed class GetAccessHistoryQuery : IRequest<Result<PaginationResponse<AccessRecordListItemDTO>>>
    {
        public PaginationRequest Pagination { get; set; } = PaginationRequest.Standart();
        public Guid? EmployeeId { get; set; }
        public Guid? AccessPointId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public AccessResult? Outcome { get; set; }  
    }
}

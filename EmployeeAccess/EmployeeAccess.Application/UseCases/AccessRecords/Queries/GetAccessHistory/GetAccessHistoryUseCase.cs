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
    public sealed class GetAccessHistoryUseCase :
        BaseHandler,
        IRequestHandler<GetAccessHistoryQuery, Result<PaginationResponse<AccessRecordListItemDTO>>>
    {
        private readonly IAccessRecordsRepository _repository;

        public GetAccessHistoryUseCase(IAccessRecordsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<PaginationResponse<AccessRecordListItemDTO>>> Handle(GetAccessHistoryQuery query)
        {
            return await ExecuteAsync(async () =>
            {
                PaginationRequest pagination = query.Pagination;

                PaginationResponse<AccessRecord> response = await _repository.GetPagedListAsync(
                    pagination, query.EmployeeId, query.AccessPointId, query.From, query.To, query.Outcome);

                List<AccessRecordListItemDTO> items = response.Items.Select(r => r.ToListItemDTO()).ToList();

                return PaginationResponse<AccessRecordListItemDTO>.Create(items, response.TotalCount, pagination);
            });
        }
    }
}

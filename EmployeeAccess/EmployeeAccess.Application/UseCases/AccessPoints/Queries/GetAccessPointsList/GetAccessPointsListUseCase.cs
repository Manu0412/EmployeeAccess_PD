using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.AccessControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessPoints.Queries.GetAccessPointsList
{
    public sealed class GetAccessPointsListUseCase : BaseHandler, IRequestHandler<GetAccessPointsListQuery, Result<List<AccessPointListItemDTO>>>
    {
        private readonly IAccessPointsRepository _accessPointsRepository;

        public GetAccessPointsListUseCase(IAccessPointsRepository accessPointsRepository)
        {
            _accessPointsRepository = accessPointsRepository;
        }

        public async Task<Result<List<AccessPointListItemDTO>>> Handle(GetAccessPointsListQuery query)
        {
            return await ExecuteAsync(async () =>
            {
                IEnumerable<AccessPoint> accessPoints = await _accessPointsRepository.GetFilteredListAsync(query.IsEnabled);

                return accessPoints.Select(a => a.ToListItemDTO()).ToList();
            });
        }
    }
}

using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessPoints.Queries.GetAccessPointsList;

public sealed class GetAccessPointsListQuery : IRequest<Result<List<AccessPointListItemDTO>>>
{
    public bool? IsEnabled { get; set; }
}

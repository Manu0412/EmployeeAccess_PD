using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessPoints.Queries.GetAccessPointsList;

public sealed class AccessPointListItemDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public bool IsEnabled { get; init; }
}

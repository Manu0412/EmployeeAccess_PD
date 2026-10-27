using EmployeeAccess.Domain.Entities.AccessControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.AccessPoints.Queries.GetAccessPointsList;

internal static class MapperExtensions
{
    public static AccessPointListItemDTO ToListItemDTO(this AccessPoint accessPoint)
    {
        return new AccessPointListItemDTO
        {
            Id = accessPoint.Id,
            Name = accessPoint.Name,
            Description = accessPoint.Description,
            IsEnabled = accessPoint.IsEnabled
        };
    }
}

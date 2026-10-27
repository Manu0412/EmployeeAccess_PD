using EmployeeAccess.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeesList;

internal static class MapperExtensions
{
    public static EmployeeListItemDTO ToListItemDTO(this Employee employee)
    {
        return new EmployeeListItemDTO
        {
            Id = employee.Id,
            IdentificationNumber = employee.IdentificationNumber,
            FullName = $"{employee.FirstName} {employee.LastName}",
            Email = employee.Email.Value,
            Position = employee.Position,
            Area = employee.Area,
            Status = employee.Status
        };
    }
}

using EmployeeAccess.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeeById;

internal static class MapperExtensions
{
    public static EmployeeDetailsDTO ToDetailsDTO(this Employee employee)
    {
        return new EmployeeDetailsDTO
        {
            Id = employee.Id,
            IdentificationNumber = employee.IdentificationNumber,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email.Value,
            Position = employee.Position,
            Area = employee.Area,
            Status = employee.Status,
            CreatedAt = employee.CreatedAt
        };
    }
}

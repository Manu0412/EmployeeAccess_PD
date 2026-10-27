using EmployeeAccess.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeeById;

public sealed class EmployeeDetailsDTO
{
    public Guid Id { get; init; }
    public string IdentificationNumber { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Position { get; init; } = null!;
    public string Area { get; init; } = null!;
    public EmployeeStatus Status { get; init; }
    public DateTime CreatedAt { get; init; }
}

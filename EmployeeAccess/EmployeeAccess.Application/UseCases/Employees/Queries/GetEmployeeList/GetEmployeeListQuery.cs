using EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeesList;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeesList;

public sealed class GetEmployeesListQuery : IRequest<Result<PaginationResponse<EmployeeListItemDTO>>>
{
    public PaginationRequest Pagination { get; set; } = PaginationRequest.Standart();
    public string? Area { get; set; }
    public EmployeeStatus? Status { get; set; }
}

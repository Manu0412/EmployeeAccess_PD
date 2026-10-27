using EmployeeAccess.Application.Contracts.Repositories;
using EmployeeAccess.Application.UseCases.Common;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeesList;

public sealed class GetEmployeesListUseCase :
    BaseHandler,
    IRequestHandler<GetEmployeesListQuery, Result<PaginationResponse<EmployeeListItemDTO>>>
{
    private readonly IEmployeesRepository _employeesRepository;

    public GetEmployeesListUseCase(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<Result<PaginationResponse<EmployeeListItemDTO>>> Handle(GetEmployeesListQuery query)
    {
        return await ExecuteAsync(async () =>
        {
            PaginationRequest pagination = query.Pagination;

            PaginationResponse<Employee> response = await _employeesRepository.GetPagedListAsync(
                pagination, query.Area, query.Status);

            List<EmployeeListItemDTO> items = response.Items.Select(e => e.ToListItemDTO()).ToList();

            return PaginationResponse<EmployeeListItemDTO>.Create(items, response.TotalCount, pagination);
        });
    }
}

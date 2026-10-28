using EmployeeAccess.Api.DTOs.Employees;
using EmployeeAccess.Application.UseCases.Employees.Commands.DesactivateEmployee;
using EmployeeAccess.Application.UseCases.Employees.Commands.RegisterEmployee;
using EmployeeAccess.Application.UseCases.Employees.Commands.UpdateEmployee;
using EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeeById;
using EmployeeAccess.Application.UseCases.Employees.Queries.GetEmployeesList;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAccess.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : ApiController
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1,
                                                 [FromQuery] int pageSize = PaginationRequest.DEFAULT_PAGE_SIZE,
                                                 [FromQuery] string? area = null,
                                                 [FromQuery] EmployeeStatus? status = null)
        {
            GetEmployeesListQuery query = new()
            {
                Pagination = new PaginationRequest(pageNumber, pageSize),
                Area = area,
                Status = status
            };

            Result<PaginationResponse<EmployeeListItemDTO>> result = await _mediator.Send(query);

            return ToActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetEmployeeByIdQuery query = new() { Id = id };

            Result<EmployeeDetailsDTO> result = await _mediator.Send(query);

            return ToActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateEmployeeDTO request)
        {
            RegisterEmployeeCommand command = new()
            {
                IdentificationNumber = request.IdentificationNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Position = request.Position,
                Area = request.Area
            };

            Result<Guid> result = await _mediator.Send(command);

            return ToActionResult(result, StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDTO request)
        {
            UpdateEmployeeCommand command = new()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Position = request.Position,
                Area = request.Area
            };

            Result<Guid> result = await _mediator.Send(command);

            return ToActionResult(result);
        }

        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> Deactivate([FromRoute] Guid id)
        {
            DeactivateEmployeeCommand command = new() { Id = id };

            Result<Guid> result = await _mediator.Send(command);

            return ToActionResult(result);
        }
    }
}

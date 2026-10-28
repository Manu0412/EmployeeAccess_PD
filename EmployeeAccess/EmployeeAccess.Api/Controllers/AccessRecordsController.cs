using EmployeeAccess.Api.DTOs.AccessRecords;
using EmployeeAccess.Application.UseCases.AccessRecords.Commands.RegisterAccess;
using EmployeeAccess.Application.UseCases.AccessRecords.Queries.GetAccessHistory;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Pagination;
using EmployeeAccess.Application.Utilities.Results;
using EmployeeAccess.Domain.Entities.AccessControl;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAccess.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccessRecordsController : ApiController
    {
        private readonly IMediator _mediator;

        public AccessRecordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterAccessDTO request)
        {
            RegisterAccessCommand command = new()
            {
                CredentialCode = request.CredentialCode,
                AccessPointId = request.AccessPointId,
                Movement = request.Movement
            };

            Result<RegisterAccessResultDTO> result = await _mediator.Send(command);

            return ToActionResult(result, StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory([FromQuery] int pageNumber = 1,
                                                    [FromQuery] int pageSize = PaginationRequest.DEFAULT_PAGE_SIZE,
                                                    [FromQuery] Guid? employeeId = null,
                                                    [FromQuery] Guid? accessPointId = null,
                                                    [FromQuery] DateTime? fromDate = null,
                                                    [FromQuery] DateTime? toDate = null,
                                                    [FromQuery] AccessResult? outcome = null)
        {
            GetAccessHistoryQuery query = new()
            {
                Pagination = new PaginationRequest(pageNumber, pageSize),
                EmployeeId = employeeId,
                AccessPointId = accessPointId,
                From = fromDate,
                To = toDate,
                Outcome = outcome
            };

            Result<PaginationResponse<AccessRecordListItemDTO>> result = await _mediator.Send(query);

            return ToActionResult(result);
        }
    }
}

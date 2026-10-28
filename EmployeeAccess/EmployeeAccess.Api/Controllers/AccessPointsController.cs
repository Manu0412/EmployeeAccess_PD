using EmployeeAccess.Api.DTOs.AccessPoints;
using EmployeeAccess.Application.UseCases.AccessPoints.Commands.RegisterAccessPoint;
using EmployeeAccess.Application.UseCases.AccessPoints.Queries.GetAccessPointsList;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAccess.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccessPointsController : ApiController
    {
        private readonly IMediator _mediator;

        public AccessPointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] bool? isEnabled = null)
        {
            GetAccessPointsListQuery query = new() { IsEnabled = isEnabled };

            Result<List<AccessPointListItemDTO>> result = await _mediator.Send(query);

            return ToActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateAccessPointDTO request)
        {
            RegisterAccessPointCommand command = new()
            {
                Name = request.Name,
                Description = request.Description
            };

            Result<Guid> result = await _mediator.Send(command);

            return ToActionResult(result, StatusCodes.Status201Created);
        }
    }
}

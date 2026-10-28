using EmployeeAccess.Api.DTOs.Credentials;
using EmployeeAccess.Application.UseCases.Credentials.Commands.AssignCredential;
using EmployeeAccess.Application.UseCases.Credentials.Commands.BlockCredential;
using EmployeeAccess.Application.UseCases.Credentials.Commands.RevokeCredential;
using EmployeeAccess.Application.UseCases.Credentials.Queries.GetCredentialStatus;
using EmployeeAccess.Application.Utilities.Mediator;
using EmployeeAccess.Application.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAccess.Api.Controllers
{
    [Route("api/[controller]")]
    public class CredentialsController : ApiController
    {
        private readonly IMediator _mediator;

        public CredentialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Assign([FromBody] AssignCredentialDTO request)
        {
            AssignCredentialCommand command = new()
            {
                EmployeeId = request.EmployeeId,
                Code = request.Code
            };

            Result<Guid> result = await _mediator.Send(command);

            return ToActionResult(result, StatusCodes.Status201Created);
        }

        [HttpGet("{code}/status")]
        public async Task<IActionResult> GetStatus([FromRoute] string code)
        {
            GetCredentialStatusQuery query = new() { Code = code };

            Result<CredentialStatusDTO> result = await _mediator.Send(query);

            return ToActionResult(result);
        }

        [HttpPatch("{id}/block")]
        public async Task<IActionResult> Block([FromRoute] Guid id)
        {
            BlockCredentialCommand command = new() { Id = id };

            Result<Guid> result = await _mediator.Send(command);

            return ToActionResult(result);
        }

        [HttpPatch("{id}/revoke")]
        public async Task<IActionResult> Revoke([FromRoute] Guid id)
        {
            RevokeCredentialCommand command = new() { Id = id };

            Result<Guid> result = await _mediator.Send(command);

            return ToActionResult(result);
        }
    }
}

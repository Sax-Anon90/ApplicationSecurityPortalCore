using ApplicationSecurity.Application.IdentityAccessManagement.Features.Users.Commands;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityApi.Api.Controllers.IdentityAccessManagement.v1.Authentication
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateUser(AuthenticateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

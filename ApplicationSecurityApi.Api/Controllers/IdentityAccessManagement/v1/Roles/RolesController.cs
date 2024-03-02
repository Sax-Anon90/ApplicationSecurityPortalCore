using ApplicationSecurity.Application.IdentityAccessManagement.Features.Roles.Commands;
using ApplicationSecurity.Application.IdentityAccessManagement.Features.Roles.Queries;
using ApplicationSecurityApi.Api.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityApi.Api.Controllers.IdentityAccessManagement.v1.Roles
{
    public class RolesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await Mediator.Send(new GetAllRolesQuery()));
        }

        [HttpGet("{RoleId}")]
        public async Task<IActionResult> GetRoleById(int RoleId)
        {
            return Ok(await Mediator.Send(new GetRoleByIdQuery { Roleid = RoleId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{RoleId}")]
        public async Task<IActionResult> DeleteRole(int RoleId)
        {
            return Ok(await Mediator.Send(new DeleteRoleCommand { RoleId = RoleId }));
        }
    }
}

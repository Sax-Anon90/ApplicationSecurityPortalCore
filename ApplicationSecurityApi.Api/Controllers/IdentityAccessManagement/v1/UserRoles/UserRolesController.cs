using ApplicationSecurity.Application.IdentityAccessManagement.Features.UserRoles.Commands;
using ApplicationSecurity.Application.IdentityAccessManagement.Features.UserRoles.Queries;
using ApplicationSecurityApi.Api.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityApi.Api.Controllers.IdentityAccessManagement.v1.UserRoles
{
    public class UserRolesController : BaseApiController
    {
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserRolesByUserId(int UserId)
        {
            return Ok(await Mediator.Send(new GetUserRolesByUserIdQuery { UserId = UserId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRole(CreateUserRoleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{UserRoleId}")]
        public async Task<IActionResult> DeleteUserRole(int UserRoleId)
        {
            return Ok(await Mediator.Send(new DeleteUserRoleCommand { UserRoleId = UserRoleId }));
        }
    }
}

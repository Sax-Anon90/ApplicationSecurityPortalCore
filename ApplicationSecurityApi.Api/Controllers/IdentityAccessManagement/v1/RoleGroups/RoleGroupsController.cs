using ApplicationSecurity.Application.IdentityAccessManagement.Features.RoleGroups.Commands;
using ApplicationSecurity.Application.IdentityAccessManagement.Features.RoleGroups.Queries;
using ApplicationSecurityApi.Api.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityApi.Api.Controllers.IdentityAccessManagement.v1.RoleGroups
{
    public class RoleGroupsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRoleGroups()
        {
            return Ok(await Mediator.Send(new GetAllRoleGroupsQuery()));
        }

        [HttpGet("{RoleGroupId}")]
        public async Task<IActionResult> GetRoleGroupById(int RoleGroupId)
        {
            return Ok(await Mediator.Send(new GetRoleGroupByIdQuery { RoleGroupId = RoleGroupId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleGroup(CreateRoleGroupCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoleGroup(UpdateRoleGroupCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{RoleGroupId}")]
        public async Task<IActionResult> DeleteRoleGroup(int RoleGroupId)
        {
            return Ok(await Mediator.Send(new DeleteRoleGroupCommand { RoleGroupId = RoleGroupId }));
        }
    }
}

using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.RoleGroups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityPortal.WASM.Server.Controllers.IdentityAccessManagement.RoleGroups
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleGroupsController : ControllerBase
    {
        private readonly IRoleGroupsServiceAsync _roleGroupsService;
        public RoleGroupsController(IRoleGroupsServiceAsync _roleGroupsService)
        {
            this._roleGroupsService = _roleGroupsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoleGroups()
        {
            return Ok(await _roleGroupsService.GetAllRoleGroupsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleGroup([FromBody] RoleGroupsInputModel roleGroupsInputModel)
        {
            return Ok(await _roleGroupsService.CreateRoleGroupAsync(roleGroupsInputModel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoleGroup([FromBody] RoleGroupsUpdateModel roleGroupsUpdateModel)
        {
            return Ok(await _roleGroupsService.
                UpdateRoleGroupAsync(roleGroupsUpdateModel));
        }

        [HttpDelete("{roleGroupId}")]
        public async Task<IActionResult> DeleteRoleGroup(int roleGroupId)
        {
            return Ok(await _roleGroupsService
                    .DeleteRoleGroupAsync(roleGroupId));
        }

    }
}

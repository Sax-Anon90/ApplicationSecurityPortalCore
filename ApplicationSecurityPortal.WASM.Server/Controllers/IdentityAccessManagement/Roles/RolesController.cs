using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.Roles;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityPortal.WASM.Server.Controllers.IdentityAccessManagement.Roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesServiceAsync _rolesServiceAsync;
        public RolesController(IRolesServiceAsync _rolesServiceAsync)
        {
            this._rolesServiceAsync = _rolesServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles() 
        {
            return Ok(await _rolesServiceAsync.GetAllRolesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RolesInputModel rolesInputModel)
        {
            return Ok(await _rolesServiceAsync.AddRoleAsync(rolesInputModel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] RolesUpdateModel rolesUpdateModel)
        {
            return Ok(await _rolesServiceAsync.UpdateRoleAsync(rolesUpdateModel));
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            return Ok(await _rolesServiceAsync.DeleteRoleAsync(roleId));
        }

    }
}

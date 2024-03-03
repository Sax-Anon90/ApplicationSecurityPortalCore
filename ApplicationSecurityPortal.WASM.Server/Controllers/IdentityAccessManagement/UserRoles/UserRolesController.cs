using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.UserRoles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityPortal.WASM.Server.Controllers.IdentityAccessManagement.UserRoles
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleServiceAsync _userRoleService;
        public UserRolesController(IUserRoleServiceAsync _userRoleService)
        {
            this._userRoleService = _userRoleService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserRolesByUserId(int UserId)
        {
            return Ok(await _userRoleService.GetUserRolesByUserIdAsync(UserId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRole([FromBody] UserRoleInputModel userRoleInputModel)
        {
            return Ok(await _userRoleService.CreateUserRoleAsync(userRoleInputModel));
        }

        [HttpDelete("{userRoleId}")]
        public async Task<IActionResult> DeleteUserRole(int UserRoleId)
        {
            return Ok(await _userRoleService.DeleteUserRoleAsync(UserRoleId));
        }

    }
}

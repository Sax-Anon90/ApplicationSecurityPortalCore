using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.Users;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityPortal.WASM.Server.Controllers.IdentityAccessManagement.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServiceAsync _usersService;
        public UsersController(IUsersServiceAsync _usersService)
        {
            this._usersService = _usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _usersService.GetAllUsersAsync());
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserByUserId(int UserId)
        {
            return Ok(await _usersService.GetUserByUserIdAsync(UserId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsersInputModel usersInputModel)
        {
            return Ok(await _usersService.CreateUserAsync(usersInputModel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UsersUpdateModel usersUpdateModel)
        {
            return Ok(await _usersService.UpdateUserAsync(usersUpdateModel));
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            return Ok(await _usersService.DeleteUserAsync(UserId));
        }

        [HttpGet("{UserCode}/UserCode")]
        public async Task<IActionResult> GetUserByUserCode(string UserCode)
        {
            return Ok(await _usersService.GetUserByUserCodeAsync(UserCode));
        }


    }
}

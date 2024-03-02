using ApplicationSecurity.Application.IdentityAccessManagement.Features.Users.Commands;
using ApplicationSecurity.Application.IdentityAccessManagement.Features.Users.Queries;
using ApplicationSecurityApi.Api.Controllers.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityApi.Api.Controllers.IdentityAccessManagement.v1.Users
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserByUserId(int UserId)
        {
            return Ok(await Mediator.Send(new GetUserByUserIdQuery { UserId = UserId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand { UserId = UserId }));
        }

        [HttpGet("{UserCode}/UserCode")]
        public async Task<IActionResult> GetUserByUserCode(string UserCode)
        {
            return Ok(await Mediator.Send(new GetUserByUserCodeQuery { UserCode = UserCode }));
        }

    }
}

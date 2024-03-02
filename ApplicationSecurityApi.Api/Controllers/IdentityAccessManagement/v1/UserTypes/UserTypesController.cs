using ApplicationSecurity.Application.IdentityAccessManagement.Features.UserTypes.Commands;
using ApplicationSecurity.Application.IdentityAccessManagement.Features.UserTypes.Queries;
using ApplicationSecurityApi.Api.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityApi.Api.Controllers.IdentityAccessManagement.v1.UserTypes
{
    public class UserTypesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUserTypes()
        {
            return Ok(await Mediator.Send(new GetAllUserTypesQuery()));
        }

        [HttpGet("{UserTypeId}")]
        public async Task<IActionResult> GetUserTypeById(int UserTypeId)
        {
            return Ok(await Mediator.Send(new GetUserTypeByUserTypeIdQuery { UserTypeId = UserTypeId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserType(CreateUserTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserType(UpdateUserTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{UserTypeId}")]
        public async Task<IActionResult> DeleteUserType(int UserTypeId)
        {
            return Ok(await Mediator.Send(new DeleteUserTypeCommand { UserTypeId = UserTypeId }));
        }

    }
}

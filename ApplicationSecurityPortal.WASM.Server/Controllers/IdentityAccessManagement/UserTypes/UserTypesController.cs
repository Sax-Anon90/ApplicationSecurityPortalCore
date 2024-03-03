using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.UserTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityPortal.WASM.Server.Controllers.IdentityAccessManagement.UserTypes
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypesServiceAsync _userTypesServiceAsync;
        public UserTypesController(IUserTypesServiceAsync _userTypesServiceAsync)
        {
            this._userTypesServiceAsync = _userTypesServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserTypes()
        {
            return Ok(await _userTypesServiceAsync.GetAllUserTypesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserType(UserTypesInputModel userTypesInputModel)
        {
            return Ok(await _userTypesServiceAsync.CreateUserTypeAsync(userTypesInputModel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserType(UserTypesUpdateModel userTypesUpdateModel)
        {
            return Ok(await _userTypesServiceAsync.UpdateUserTypesAsync(userTypesUpdateModel));
        }

        [HttpDelete("{UserTypeId}")]
        public async Task<IActionResult> DeleteUserType(int UserTypeId)
        {
            return Ok(await _userTypesServiceAsync.DeleteUserTypesAsync(UserTypeId));
        }
    }
}
    
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.CustomerApplications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityPortal.WASM.Server.Controllers.IdentityAccessManagement.CustomerApplications
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApplicationsController : ControllerBase
    {
        private readonly ICustomerApplicationsServiceAsync _customerApplicationsServiceAsync;
        public CustomerApplicationsController(ICustomerApplicationsServiceAsync 
            _customerApplicationsServiceAsync)
        {
            this._customerApplicationsServiceAsync = _customerApplicationsServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomerApplications()
        {
            return Ok(await _customerApplicationsServiceAsync
                .GetAllCustomerApplicationsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerApplication([FromBody] CustomerApplicationsInputModel
            customerApplicationsInputModel)
        {
            return Ok(await _customerApplicationsServiceAsync
                .CreateCustomerApplicationAsync(customerApplicationsInputModel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerApplication([FromBody] CustomerApplicationsUpdateModel
            customerApplicationsUpdateModel)
        {
            return Ok(await _customerApplicationsServiceAsync
                .UpdateCustomerApplicationAsync(customerApplicationsUpdateModel));
        }

        [HttpDelete("{customerApplicationId}")]
        public async Task<IActionResult> DeleteCustomerApplication(int customerApplicationId)
        {
            return Ok(await _customerApplicationsServiceAsync
                .DeleteCustomerApplicationAsync(customerApplicationId));
        }

        [HttpGet("{customerApplicationId}/RoleGroupRoles/")]
        public async Task<IActionResult> GetCustomerApplicationsRoleGroupsWithRoles(int customerApplicationId)
        {
            return Ok(await _customerApplicationsServiceAsync
                .GetCustomerApplicationsRoleGroupsWithRoles(customerApplicationId));
        }
    }
}

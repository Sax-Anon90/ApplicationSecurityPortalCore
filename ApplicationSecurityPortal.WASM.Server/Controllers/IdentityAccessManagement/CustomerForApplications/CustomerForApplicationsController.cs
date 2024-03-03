using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.CustomerForApplications;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.CustomerForApplications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityPortal.WASM.Server.Controllers.IdentityAccessManagement.CustomerForApplications
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerForApplicationsController : ControllerBase
    {
        private readonly ICustomerForApplicationServiceAsync _customerForApplicationServiceAsync;
        public CustomerForApplicationsController(ICustomerForApplicationServiceAsync _customerForApplicationServiceAsync)
        {
            this._customerForApplicationServiceAsync = _customerForApplicationServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomerForApplications()
        {
            return Ok(await _customerForApplicationServiceAsync
                .GetAllCustomerForApplicationsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerForApplication([FromBody] CustomerForApplicationsInputModel
            customerForApplicationModel)
        {
            return Ok(await _customerForApplicationServiceAsync
                .CreateCustomerForApplicationAsync(customerForApplicationModel));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerForApplication([FromBody] CustomerForApplicationsUpdateModel
            customerForApplicationsUpdateModel)
        {
            return Ok(await _customerForApplicationServiceAsync
                .UpdateCustomerForApplicationAsync(customerForApplicationsUpdateModel));
        }

        [HttpDelete("{customerForApplicationId}")]
        public async Task<IActionResult> DeleteCustomerForApplication(int customerForApplicationId)
        {
            return Ok(await _customerForApplicationServiceAsync
                .DeleteCustomerForApplicationAsync(customerForApplicationId));
        }

    }
}

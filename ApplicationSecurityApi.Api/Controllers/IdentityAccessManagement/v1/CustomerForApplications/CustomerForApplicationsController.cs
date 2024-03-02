using ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerForApplications.Commands;
using ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerForApplications.Queries;
using ApplicationSecurityApi.Api.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityApi.Api.Controllers.IdentityAccessManagement.v1.CustomerForApplications
{
    public class CustomerForApplicationsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCustomerForApplications()
        {
            return Ok(await Mediator.Send(new GetAllCustomerForApplicationsQuery()));
        }

        [HttpGet("{customerForApplicationId}")]
        public async Task<IActionResult> GetCustomerForApplicationById(int customerForApplicationId)
        {
            return Ok(await Mediator.Send(new GetCustomerForApplicationByIdQuery { customerForApplicationId = customerForApplicationId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerForApplication(CreateCustomerForApplicationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerForApplication(UpdateCustomerForApplicationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{customerForApplicationId}")]
        public async Task<IActionResult> DeleteCustomerForApplication(int customerForApplicationId)
        {
            return Ok(await Mediator.Send(new DeleteCustomerForApplicationCommand { CustomerForApplicationId = customerForApplicationId }));
        }
    }
}

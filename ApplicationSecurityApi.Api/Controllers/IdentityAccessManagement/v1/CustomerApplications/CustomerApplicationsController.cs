using ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerApplications.Commands;
using ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerApplications.Queries;
using ApplicationSecurityApi.Api.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSecurityApi.Api.Controllers.IdentityAccessManagement.v1.CustomerApplications
{
    public class CustomerApplicationsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCustomerApplications()
        {
            return Ok(await Mediator.Send(new GetAllCustomerApplicationsQuery()));
        }

        [HttpGet("{customerApplicationId}")]
        public async Task<IActionResult> GetCustomerApplicationById(int customerApplicationId)
        {
            return Ok(await Mediator.Send(new GetCustomerApplicationByIdQuery { customerApplicationId = customerApplicationId }));

        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerApplication(CreateCustomerApplicationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerApplication(UpdateCustomerApplicationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{customerApplicationId}")]
        public async Task<IActionResult> DeleteCustomerApplication(int customerApplicationId)
        {
            return Ok(await Mediator.Send(new DeleteCustomerApplicationCommand { CustomerApplicationId = customerApplicationId }));
        }

        [HttpGet("{customerApplicationId}/RoleGroupRoles/")]
        public async Task<IActionResult> GetCustomerApplicationsRoleGroupsWithRoles(int customerApplicationId)
        {
            return Ok(await Mediator.Send(new GetCustomerApplicationsRoleGroupsWithRolesQuery { customerApplicationId = customerApplicationId }));
        }
    }
}

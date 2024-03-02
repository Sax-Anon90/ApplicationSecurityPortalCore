using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerForApplications.Commands
{
    public class DeleteCustomerForApplicationCommand : IRequest<Response<CustomerForApplication>>
    {
        public int CustomerForApplicationId { get; set; }
        public class DeleteCustomerForApplicationCommandHandler : IRequestHandler<DeleteCustomerForApplicationCommand, Response<CustomerForApplication>>
        {
            private readonly ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync;
            public DeleteCustomerForApplicationCommandHandler(ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync)
            {
                this._customerForApplicationRepositoryAsync = _customerForApplicationRepositoryAsync;
            }
            public async Task<Response<CustomerForApplication>> Handle(DeleteCustomerForApplicationCommand request, CancellationToken cancellationToken)
            {
                var _customerForApplicationToMakeInactive = new CustomerForApplication()
                {
                    Id = request.CustomerForApplicationId,
                };

                var customerForApplicationToMakeInactiveResponse = await _customerForApplicationRepositoryAsync.DeleteCustomerForApplicationAsync(_customerForApplicationToMakeInactive);

                if (customerForApplicationToMakeInactiveResponse.Id == 0)
                {
                    return new Response<CustomerForApplication>()
                    {
                        Succeeded = false,
                        Message = $"Customer for application not found to make inactive",
                        Data = null
                    };
                }

                return new Response<CustomerForApplication>()
                {
                    Succeeded = true,
                    Message = $"Customer for application is now Inactive",
                    Data = customerForApplicationToMakeInactiveResponse
                };

            }
        }
    }
}

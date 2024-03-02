using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.CustomerForApplications;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerForApplications.Commands
{
    public class UpdateCustomerForApplicationCommand : IRequest<Response<CustomerForApplication>>
    {
        public UpdateCustomerForApplicationModel customerForApplicationToUpdate { get; set; }
        public class UpdateCustomerForApplicationCommandHandler : IRequestHandler<UpdateCustomerForApplicationCommand, Response<CustomerForApplication>>
        {
            private readonly ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync;
            public UpdateCustomerForApplicationCommandHandler(ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync)
            {
                this._customerForApplicationRepositoryAsync = _customerForApplicationRepositoryAsync;
            }
            public async Task<Response<CustomerForApplication>> Handle(UpdateCustomerForApplicationCommand request, CancellationToken cancellationToken)
            {
                var _customerForApplicationToUpdate = new CustomerForApplication()
                {
                    Id = request.customerForApplicationToUpdate.Id,
                    Name = request.customerForApplicationToUpdate.Name,
                    Description = request.customerForApplicationToUpdate.Description

                };

                var customerForUpdateResponse = await _customerForApplicationRepositoryAsync.UpdateCustomerForApplicationAsync(_customerForApplicationToUpdate);

                if (customerForUpdateResponse.Id == 0)
                {
                    return new Response<CustomerForApplication>()
                    {
                        Succeeded = false,
                        Message = $"Customer For Application not found to update",
                        Data = null
                    };
                }

                return new Response<CustomerForApplication>()
                {
                    Succeeded = true,
                    Message = $"Customer for application updated successfully",
                    Data = customerForUpdateResponse
                };
            }
        }
    }
}

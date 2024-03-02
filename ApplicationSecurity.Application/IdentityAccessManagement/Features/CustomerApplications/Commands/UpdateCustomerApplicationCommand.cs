using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.CustomerApplications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerApplications.Commands
{
    public class UpdateCustomerApplicationCommand : IRequest<Response<CustomerApplication>>
    {
        public UpdateCustomerApplicationsModel customerApplicationToUpdate { get; set; }
        public class UpdateCustomerApplicationCommandHandler : IRequestHandler<UpdateCustomerApplicationCommand, Response<CustomerApplication>>
        {
            private readonly ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync;
            public UpdateCustomerApplicationCommandHandler(ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync)
            {
                this._customerApplicationRepositoryAsync = _customerApplicationRepositoryAsync;
            }
            public async Task<Response<CustomerApplication>> Handle(UpdateCustomerApplicationCommand request, CancellationToken cancellationToken)
            {
                var _customerApplicationToUpdate = new CustomerApplication()
                {
                    Id = request.customerApplicationToUpdate.Id,
                    CustomerForApplicationId = request.customerApplicationToUpdate.CustomerForApplicationId,
                    Name = request.customerApplicationToUpdate.Name,
                    Description = request.customerApplicationToUpdate.Description
                };

                var _customerApplicationToUpdateResponse = await _customerApplicationRepositoryAsync.UpdateCustomerApplicationAsync(_customerApplicationToUpdate);

                if (_customerApplicationToUpdateResponse.Id == 0)
                {
                    return new Response<CustomerApplication>()
                    {
                        Succeeded = false,
                        Message = $"Customer application not found to update",
                        Data = null
                    };
                }

                return new Response<CustomerApplication>()
                {
                    Succeeded = true,
                    Message = $"Customer application updated successfully",
                    Data = _customerApplicationToUpdateResponse
                };
            }
        }
    }
}

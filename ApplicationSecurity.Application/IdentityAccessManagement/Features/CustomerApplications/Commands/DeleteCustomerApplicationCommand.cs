using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerApplications.Commands
{
    public class DeleteCustomerApplicationCommand : IRequest<Response<CustomerApplication>>
    {
        public int CustomerApplicationId { get; set; }
        public class DeleteCustomerApplicationCommandHandler : IRequestHandler<DeleteCustomerApplicationCommand, Response<CustomerApplication>>
        {
            private readonly ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync;

            public DeleteCustomerApplicationCommandHandler(ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync)
            {
                this._customerApplicationRepositoryAsync = _customerApplicationRepositoryAsync;
            }
            public async Task<Response<CustomerApplication>> Handle(DeleteCustomerApplicationCommand request, CancellationToken cancellationToken)
            {
                var _customerApplicationToMakeInactive = new CustomerApplication()
                {
                    Id = request.CustomerApplicationId
                };

                var _customerApplicationToMakeInactiveResponse = await _customerApplicationRepositoryAsync.DeleteCustomerApplicationAsync(_customerApplicationToMakeInactive);

                if (_customerApplicationToMakeInactiveResponse.Id == 0)
                {
                    return new Response<CustomerApplication>()
                    {
                        Succeeded = false,
                        Message = $"Customer application not found to make inactive",
                        Data = null
                    };
                }

                return new Response<CustomerApplication>()
                {
                    Succeeded = true,
                    Message = $"Customer application is now inactive",
                    Data = _customerApplicationToMakeInactiveResponse
                };
            }
        }
    }
}

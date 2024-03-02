using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.CustomerApplications;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerApplications.Commands
{
    public class CreateCustomerApplicationCommand : IRequest<Response<CustomerApplication>>
    {
        public CustomerApplicationsModel customerApplicationToCreate { get; set; }

        public class CreateCustomerApplicationCommandHandler : IRequestHandler<CreateCustomerApplicationCommand, Response<CustomerApplication>>
        {
            private readonly ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync;
            public CreateCustomerApplicationCommandHandler(ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync)
            {
                this._customerApplicationRepositoryAsync = _customerApplicationRepositoryAsync;
            }
            public async Task<Response<CustomerApplication>> Handle(CreateCustomerApplicationCommand request, CancellationToken cancellationToken)
            {

                var _customerApplicationToCreate = new CustomerApplication()
                {
                    CustomerForApplicationId = request.customerApplicationToCreate.CustomerForApplicationId,
                    Name = request.customerApplicationToCreate.Name,
                    Description = request.customerApplicationToCreate.Description,
                    ActiveFlag = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                var createdCustomerApplication = await _customerApplicationRepositoryAsync.AddCustomerApplicationAsync(_customerApplicationToCreate);

                return new Response<CustomerApplication>()
                {
                    Succeeded = true,
                    Message = "Customer Application created successfully",
                    Data = createdCustomerApplication
                };
            }
        }
    }
}

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
    public class CreateCustomerForApplicationCommand : IRequest<Response<CustomerForApplication>>
    {
        public CustomerForApplicationModel customerForApplicationToCreate { get; set; }
        public class CreateCustomerForApplicationCommandHandler : IRequestHandler<CreateCustomerForApplicationCommand, Response<CustomerForApplication>>
        {
            private readonly ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync;
            public CreateCustomerForApplicationCommandHandler(ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync)
            {
                this._customerForApplicationRepositoryAsync = _customerForApplicationRepositoryAsync;
            }
            public async Task<Response<CustomerForApplication>> Handle(CreateCustomerForApplicationCommand request, CancellationToken cancellationToken)
            {

                var _customerForApplicationToCreate = new CustomerForApplication()
                {
                    Name = request.customerForApplicationToCreate.Name,
                    Description = request.customerForApplicationToCreate.Description,
                    ActiveFlag = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    DateInactive = null
                };

                var createdCustomerForApplication = await _customerForApplicationRepositoryAsync.AddCustomerForApplicationAsync(_customerForApplicationToCreate);

                return new Response<CustomerForApplication>()
                {
                    Succeeded = true,
                    Message = "Customer for application created successfully",
                    Data = createdCustomerForApplication
                };
            }
        }
    }
}

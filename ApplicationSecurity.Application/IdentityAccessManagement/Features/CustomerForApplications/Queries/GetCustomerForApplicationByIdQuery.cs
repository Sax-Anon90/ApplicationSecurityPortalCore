using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.CustomerForApplications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerForApplications.Queries
{
    public class GetCustomerForApplicationByIdQuery : IRequest<Response<CustomerForApplicationViewModel>>
    {
        public int customerForApplicationId { get; set; }
        public class GetCustomerForApplicationByIdQueryHandler : IRequestHandler<GetCustomerForApplicationByIdQuery, Response<CustomerForApplicationViewModel>>
        {
            private readonly ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync;
            public GetCustomerForApplicationByIdQueryHandler(ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync)
            {
                this._customerForApplicationRepositoryAsync = _customerForApplicationRepositoryAsync;
            }
            public async Task<Response<CustomerForApplicationViewModel>> Handle(GetCustomerForApplicationByIdQuery request, CancellationToken cancellationToken)
            {
                var customerForApplication = await _customerForApplicationRepositoryAsync.GetCustomerForApplicationByIdAsync(request.customerForApplicationId);
                if (customerForApplication.Id == null)
                {
                    return new Response<CustomerForApplicationViewModel>()
                    {
                        Succeeded = false,
                        Message = $"Customer For Application not found",
                        Data = null
                    };
                }

                return new Response<CustomerForApplicationViewModel>
                {
                    Succeeded = true,
                    Message = $"Customer For Application retreived successfully",
                    Data = customerForApplication
                };
            }
        }
    }
}

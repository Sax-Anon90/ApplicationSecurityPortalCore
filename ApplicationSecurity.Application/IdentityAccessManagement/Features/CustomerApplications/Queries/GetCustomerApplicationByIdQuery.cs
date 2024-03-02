using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.CustomerApplications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.CustomerApplications.Queries
{
    public class GetCustomerApplicationByIdQuery : IRequest<Response<CustomerApplicationViewModel>>
    {
        public int customerApplicationId { get; set; }
        public class GetCustomerApplicationByIdQueryHandler : IRequestHandler<GetCustomerApplicationByIdQuery, Response<CustomerApplicationViewModel>>
        {
            private readonly ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync;
            public GetCustomerApplicationByIdQueryHandler(ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync)
            {
                this._customerApplicationRepositoryAsync = _customerApplicationRepositoryAsync;
            }
            public async Task<Response<CustomerApplicationViewModel>> Handle(GetCustomerApplicationByIdQuery request, CancellationToken cancellationToken)
            {
                var customerApplication = await _customerApplicationRepositoryAsync.GetCustomerApplicationByIdAsync(request.customerApplicationId);

                if (customerApplication.Id == null)
                {
                    return new Response<CustomerApplicationViewModel>()
                    {
                        Succeeded = false,
                        Message = $"Customer application not found",
                        Data = null
                    };
                }

                return new Response<CustomerApplicationViewModel>()
                {
                    Succeeded = true,
                    Message = $"Customer application retreived successfully",
                    Data = customerApplication
                };

            }
        }
    }
}

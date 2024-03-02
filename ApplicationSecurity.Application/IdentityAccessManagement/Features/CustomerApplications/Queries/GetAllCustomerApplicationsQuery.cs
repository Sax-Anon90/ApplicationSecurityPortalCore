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
    public record GetAllCustomerApplicationsQuery : IRequest<Response<IEnumerable<CustomerApplicationViewModel>>>;
    public class GetAllCustomerApplicationsQueryHandler : IRequestHandler<GetAllCustomerApplicationsQuery, Response<IEnumerable<CustomerApplicationViewModel>>>
    {
        private readonly ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync;
        public GetAllCustomerApplicationsQueryHandler(ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync)
        {
            this._customerApplicationRepositoryAsync = _customerApplicationRepositoryAsync;
        }
        public async Task<Response<IEnumerable<CustomerApplicationViewModel>>> Handle(GetAllCustomerApplicationsQuery request, CancellationToken cancellationToken)
        {
            var customerApplications = await _customerApplicationRepositoryAsync.GetAllCustomerApplicationsAsync();

            if (customerApplications.Count() == 0)
            {
                return new Response<IEnumerable<CustomerApplicationViewModel>>()
                {
                    Succeeded = true,
                    Message = "No Customer Applications have been found",
                    Data = Enumerable.Empty<CustomerApplicationViewModel>()
                };
            }

            return new Response<IEnumerable<CustomerApplicationViewModel>>()
            {
                Succeeded = true,
                Message = "Customer applications retreived successfully",
                Data = customerApplications
            };
        }
    }

}

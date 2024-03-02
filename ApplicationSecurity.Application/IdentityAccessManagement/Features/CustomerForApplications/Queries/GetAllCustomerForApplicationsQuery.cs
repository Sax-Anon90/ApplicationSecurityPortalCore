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
    public record GetAllCustomerForApplicationsQuery : IRequest<Response<IEnumerable<CustomerForApplicationViewModel>>>;
    public class GetAllCustomerForApplicationsQueryHandler : IRequestHandler<GetAllCustomerForApplicationsQuery, Response<IEnumerable<CustomerForApplicationViewModel>>>
    {
        private readonly ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync;
        public GetAllCustomerForApplicationsQueryHandler(ICustomerForApplicationRepositoryAsync _customerForApplicationRepositoryAsync)
        {
            this._customerForApplicationRepositoryAsync = _customerForApplicationRepositoryAsync;
        }
        public async Task<Response<IEnumerable<CustomerForApplicationViewModel>>> Handle(GetAllCustomerForApplicationsQuery request, CancellationToken cancellationToken)
        {
            var customerForApplications = await _customerForApplicationRepositoryAsync.GetAllCustomerForApplicationsAsync();

            if (customerForApplications.Count() == 0)
            {
                return new Response<IEnumerable<CustomerForApplicationViewModel>>()
                {
                    Succeeded = true,
                    Message = "No Customer for applications have been found",
                    Data = Enumerable.Empty<CustomerForApplicationViewModel>()
                };
            };

            return new Response<IEnumerable<CustomerForApplicationViewModel>>()
            {
                Succeeded = true,
                Message = "Customer applications retreived successfully",
                Data = customerForApplications
            };
        }
    }
}

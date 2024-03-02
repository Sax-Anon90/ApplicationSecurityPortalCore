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
    public class GetCustomerApplicationsRoleGroupsWithRolesQuery : IRequest<Response<CustomerApplicationRoleGroupRoles>>
    {
        public int customerApplicationId { get; set; }

        public class GetCustomerApplicationsRoleGroupsWithRolesQueryHandler :
           IRequestHandler<GetCustomerApplicationsRoleGroupsWithRolesQuery, Response<CustomerApplicationRoleGroupRoles>>
        {
            private readonly ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync;
            public GetCustomerApplicationsRoleGroupsWithRolesQueryHandler(ICustomerApplicationRepositoryAsync _customerApplicationRepositoryAsync)
            {
                this._customerApplicationRepositoryAsync = _customerApplicationRepositoryAsync;
            }
            public async Task<Response<CustomerApplicationRoleGroupRoles>> Handle(GetCustomerApplicationsRoleGroupsWithRolesQuery request, CancellationToken cancellationToken)
            {
                var _result = await _customerApplicationRepositoryAsync.GetCustomerApplicationsRoleGroupsWithRolesAsync(request.customerApplicationId);
                if (_result.CustomerApplicationId == 0)
                {
                    return new Response<CustomerApplicationRoleGroupRoles>()
                    {
                        Succeeded = false,
                        Message = $"Customer not found",
                        Data = null
                    };
                }

                return new Response<CustomerApplicationRoleGroupRoles>()
                {
                    Succeeded = true,
                    Message = $"Customer application retreived successfully",
                    Data = _result
                };
            }
        }
    }
}

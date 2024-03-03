using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.CustomerApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications
{
    public interface ICustomerApplicationsServiceAsync
    {
        Task<Response<IEnumerable<CustomerApplicationsViewModel>>> GetAllCustomerApplicationsAsync();
        Task<Response<CustomerApplicationsViewModel>> CreateCustomerApplicationAsync(CustomerApplicationsInputModel customerApplicationsInputModel);
        Task<Response<CustomerApplicationsViewModel>> UpdateCustomerApplicationAsync(CustomerApplicationsUpdateModel customerApplicationsUpdateModel);
        Task<Response<CustomerApplicationsViewModel>> DeleteCustomerApplicationAsync(int customerApplicationId);
        Task<Response<CustomerApplicationRoleGroupRoles>> GetCustomerApplicationsRoleGroupsWithRoles(int customerApplicationId);
    }
}

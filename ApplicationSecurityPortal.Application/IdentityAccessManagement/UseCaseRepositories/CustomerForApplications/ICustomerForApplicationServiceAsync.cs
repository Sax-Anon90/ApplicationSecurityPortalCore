using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.CustomerForApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications
{
    public interface ICustomerForApplicationServiceAsync
    {
        Task<Response<IEnumerable<CustomerForApplicationsViewModel>>> GetAllCustomerForApplicationsAsync();
        Task<Response<CustomerForApplicationsViewModel>> CreateCustomerForApplicationAsync(CustomerForApplicationsInputModel customerForApplicationsInputModel);
        Task<Response<CustomerForApplicationsViewModel>> UpdateCustomerForApplicationAsync(CustomerForApplicationsUpdateModel customerForApplicationsUpdateModel);
        Task<Response<CustomerForApplicationsViewModel>> DeleteCustomerForApplicationAsync(int CustomerForApplicationId);
    }
}

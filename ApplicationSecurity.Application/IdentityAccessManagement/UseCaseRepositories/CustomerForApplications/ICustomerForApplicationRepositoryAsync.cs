using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.CustomerForApplications;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications
{
    public interface ICustomerForApplicationRepositoryAsync
    {
        Task<CustomerForApplicationViewModel> GetCustomerForApplicationByIdAsync(int customerForApplicationId);
        Task<IEnumerable<CustomerForApplicationViewModel>> GetAllCustomerForApplicationsAsync();
        Task<CustomerForApplication> AddCustomerForApplicationAsync(CustomerForApplication customerForApplicationToAdd);
        Task<CustomerForApplication> UpdateCustomerForApplicationAsync(CustomerForApplication customerForApplicationToUpdate);
        Task<CustomerForApplication> DeleteCustomerForApplicationAsync(CustomerForApplication customerForApplicationToRemove);
    }
}

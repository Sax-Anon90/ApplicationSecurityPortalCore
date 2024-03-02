using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.CustomerApplications;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications
{
    public interface ICustomerApplicationRepositoryAsync
    {
        Task<CustomerApplicationViewModel> GetCustomerApplicationByIdAsync(int customerApplicationId);
        Task<IEnumerable<CustomerApplicationViewModel>> GetAllCustomerApplicationsAsync();
        Task<CustomerApplication> AddCustomerApplicationAsync(CustomerApplication customerApplicationToAdd);
        Task<CustomerApplication> UpdateCustomerApplicationAsync(CustomerApplication customerApplicationToUpdate);
        Task<CustomerApplication> DeleteCustomerApplicationAsync(CustomerApplication customerApplicationToRemove);
        Task<CustomerApplicationRoleGroupRoles> GetCustomerApplicationsRoleGroupsWithRolesAsync(int customerApplicationId);
    }
}

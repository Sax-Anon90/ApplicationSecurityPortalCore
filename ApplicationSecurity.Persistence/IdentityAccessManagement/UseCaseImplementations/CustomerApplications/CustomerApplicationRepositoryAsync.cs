using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.CustomerApplications;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.RoleGroups;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Roles;
using ApplicationSecurity.Domain.IdentityAccessManagementDbContext;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.CustomerApplications
{
    public class CustomerApplicationRepositoryAsync : ICustomerApplicationRepositoryAsync
    {
        private readonly ApplicationDevelopmentSecuritydbContext _dbContext;
        public CustomerApplicationRepositoryAsync(ApplicationDevelopmentSecuritydbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<CustomerApplication> AddCustomerApplicationAsync(CustomerApplication customerApplicationToAdd)
        {
            await _dbContext.CustomerApplications.AddAsync(customerApplicationToAdd);
            await _dbContext.SaveChangesAsync();
            return customerApplicationToAdd;
        }

        public async Task<CustomerApplication> DeleteCustomerApplicationAsync(CustomerApplication customerApplicationToRemove)
        {
            var CustomerApplicationToRemove = await _dbContext
                .CustomerApplications
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == customerApplicationToRemove.Id && x.ActiveFlag == true);

            if (CustomerApplicationToRemove is null)
            {
                return new CustomerApplication() { Id = 0 };
            }

            CustomerApplicationToRemove.ActiveFlag = false;
            _dbContext.CustomerApplications.Update(CustomerApplicationToRemove);
            await _dbContext.SaveChangesAsync();
            return CustomerApplicationToRemove;
        }

        public async Task<IEnumerable<CustomerApplicationViewModel>> GetAllCustomerApplicationsAsync()
        {
            var _CustomerApplications = await (from CustomerApplications in _dbContext.CustomerApplications
                                               .Include(x => x.CustomerForApplication)
                                               .AsSplitQuery()

                                               where CustomerApplications.ActiveFlag == true
                                               && CustomerApplications.CustomerForApplication.ActiveFlag == true

                                               select new CustomerApplicationViewModel
                                               {
                                                   Id = CustomerApplications.Id,
                                                   CustomerForApplicationId = CustomerApplications.CustomerForApplicationId,
                                                   Name = CustomerApplications.Name,
                                                   Description = CustomerApplications.Description,
                                                   ActiveFlag = CustomerApplications.ActiveFlag,
                                                   DateCreated = CustomerApplications.DateCreated,
                                                   DateUpdated = CustomerApplications.DateUpdated,
                                                   CustomerForApplication = CustomerApplications.CustomerForApplication.Name

                                               }).AsNoTracking()
                                               .ToListAsync();

            if (_CustomerApplications is null)
            {
                return Enumerable.Empty<CustomerApplicationViewModel>();
            }
            return _CustomerApplications;
        }

        public async Task<CustomerApplicationViewModel> GetCustomerApplicationByIdAsync(int customerApplicationId)
        {
            var _CustomerApplication = await (from CustomerApplication in _dbContext.CustomerApplications
                                              .Include(x => x.CustomerForApplication)
                                              .AsSplitQuery()

                                              where CustomerApplication.ActiveFlag == true
                                              && CustomerApplication.Id == customerApplicationId
                                              && CustomerApplication.CustomerForApplication.ActiveFlag == true

                                              select new CustomerApplicationViewModel
                                              {
                                                  Id = CustomerApplication.Id,
                                                  CustomerForApplicationId = CustomerApplication.CustomerForApplicationId,
                                                  Name = CustomerApplication.Name,
                                                  Description = CustomerApplication.Description,
                                                  ActiveFlag = CustomerApplication.ActiveFlag,
                                                  DateCreated = CustomerApplication.DateCreated,
                                                  DateUpdated = CustomerApplication.DateUpdated,
                                                  CustomerForApplication = CustomerApplication.CustomerForApplication.Name

                                              }).AsNoTracking()
                                               .FirstOrDefaultAsync();

            if (_CustomerApplication is null)
            {
                return new CustomerApplicationViewModel() { Id = null };
            }
            return _CustomerApplication;
        }

        public async Task<CustomerApplicationRoleGroupRoles> GetCustomerApplicationsRoleGroupsWithRolesAsync(int customerApplicationId)
        {
            var _CustomerApplicationRoleGroupRoles = await (from customerApplication in _dbContext.CustomerApplications

                                                            where customerApplication.Id == customerApplicationId
                                                            && customerApplication.ActiveFlag == true

                                                            select new CustomerApplicationRoleGroupRoles
                                                            {
                                                                CustomerApplicationId = customerApplication.Id,
                                                                CustomerApplicationName = customerApplication.Name,
                                                                RoleGroupWithRoles = (from _roleGroup in _dbContext.RoleGroups.AsNoTracking()
                                                                                      where _roleGroup.CustomerApplicationId == customerApplication.Id

                                                                                      select new RoleGroupsWithRolesViewModel
                                                                                      {
                                                                                          Id = _roleGroup.Id,
                                                                                          Name = _roleGroup.Name,
                                                                                          Description = _roleGroup.Description,
                                                                                          CustomerApplicationId = _roleGroup.CustomerApplicationId,
                                                                                          Roles = (from _roles in _dbContext.Roles.AsNoTracking()
                                                                                                   where _roles.RoleGroupId == _roleGroup.Id

                                                                                                   select new RolesViewModel
                                                                                                   {
                                                                                                       Id = _roles.Id,
                                                                                                       Name = _roles.Name,
                                                                                                       Description = _roles.Description,
                                                                                                       RoleGroupId = _roles.RoleGroupId,
                                                                                                   }).ToList(),
                                                                                      }).ToList()

                                                            }).AsNoTracking()
                                .FirstOrDefaultAsync();

            if (_CustomerApplicationRoleGroupRoles is null)
            {
                return new CustomerApplicationRoleGroupRoles() { CustomerApplicationId = 0 };
            }

            return _CustomerApplicationRoleGroupRoles;
        }

        public async Task<CustomerApplication> UpdateCustomerApplicationAsync(CustomerApplication customerApplicationToUpdate)
        {
            var _CustomerApplicationToUpdate = await _dbContext.CustomerApplications
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == customerApplicationToUpdate.Id && x.ActiveFlag == true);

            if (_CustomerApplicationToUpdate is null)
            {
                return new CustomerApplication() { Id = 0 };
            }

            _CustomerApplicationToUpdate.CustomerForApplicationId = customerApplicationToUpdate.CustomerForApplicationId;
            _CustomerApplicationToUpdate.Description = customerApplicationToUpdate.Description;
            _CustomerApplicationToUpdate.Name = customerApplicationToUpdate.Name;
            _CustomerApplicationToUpdate.ActiveFlag = true;
            _CustomerApplicationToUpdate.DateUpdated = DateTime.Now;

            _dbContext.CustomerApplications.Update(_CustomerApplicationToUpdate);
            await _dbContext.SaveChangesAsync();
            return _CustomerApplicationToUpdate;
        }
    }
}

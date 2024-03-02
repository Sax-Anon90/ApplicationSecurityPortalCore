using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.CustomerForApplications;
using ApplicationSecurity.Domain.IdentityAccessManagementDbContext;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.CustomerForApplications
{
    public class CustomerForApplicationRepositoryAsync : ICustomerForApplicationRepositoryAsync
    {
        private readonly ApplicationDevelopmentSecuritydbContext _dbContext;
        public CustomerForApplicationRepositoryAsync(ApplicationDevelopmentSecuritydbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<CustomerForApplication> AddCustomerForApplicationAsync(CustomerForApplication customerForApplicationToAdd)
        {
            await _dbContext.CustomerForApplications.AddAsync(customerForApplicationToAdd);
            await _dbContext.SaveChangesAsync();
            return customerForApplicationToAdd;
        }

        public async Task<CustomerForApplication> DeleteCustomerForApplicationAsync(CustomerForApplication customerForApplicationToRemove)
        {
            var CustomerForApplicationToRemove = await _dbContext
                  .CustomerForApplications
                  .AsNoTracking()
                  .FirstOrDefaultAsync(x => x.Id == customerForApplicationToRemove.Id && x.ActiveFlag == true);

            if (CustomerForApplicationToRemove is null)
            {
                return new CustomerForApplication() { Id = 0 };
            }

            CustomerForApplicationToRemove.ActiveFlag = false;
            CustomerForApplicationToRemove.DateInactive = DateTime.Now;

            _dbContext.CustomerForApplications.Update(CustomerForApplicationToRemove);
            await _dbContext.SaveChangesAsync();
            return CustomerForApplicationToRemove;
        }

        public async Task<IEnumerable<CustomerForApplicationViewModel>> GetAllCustomerForApplicationsAsync()
        {
            var _CustomerForApplications = await (from CustomerForApplications in _dbContext
                                                   .CustomerForApplications
                                                   .AsSplitQuery()

                                                  where CustomerForApplications.ActiveFlag == true

                                                  select new CustomerForApplicationViewModel
                                                  {
                                                      Id = CustomerForApplications.Id,
                                                      Name = CustomerForApplications.Name,
                                                      Description = CustomerForApplications.Description,
                                                      ActiveFlag = CustomerForApplications.ActiveFlag,
                                                      DateCreated = CustomerForApplications.DateCreated,
                                                      DateUpdated = CustomerForApplications.DateUpdated,
                                                      DateInactive = CustomerForApplications.DateInactive
                                                  }
                                                  ).AsNoTracking()
                                                  .ToListAsync();

            if (_CustomerForApplications is null)
            {
                return Enumerable.Empty<CustomerForApplicationViewModel>();
            }
            return _CustomerForApplications;
        }

        public async Task<CustomerForApplicationViewModel> GetCustomerForApplicationByIdAsync(int customerForApplicationId)
        {
            var _CustomerForApplication = await (from CustomerForApplication in _dbContext
                                                 .CustomerForApplications
                                                 .AsSplitQuery()

                                                 where CustomerForApplication.ActiveFlag == true
                                                 && CustomerForApplication.Id == customerForApplicationId

                                                 select new CustomerForApplicationViewModel
                                                 {
                                                     Id = CustomerForApplication.Id,
                                                     Name = CustomerForApplication.Name,
                                                     Description = CustomerForApplication.Description,
                                                     ActiveFlag = CustomerForApplication.ActiveFlag,
                                                     DateCreated = CustomerForApplication.DateCreated,
                                                     DateUpdated = CustomerForApplication.DateUpdated,
                                                     DateInactive = CustomerForApplication.DateInactive
                                                 }

                                               ).AsNoTracking()
                                               .FirstOrDefaultAsync();
            if (_CustomerForApplication is null)
            {
                return new CustomerForApplicationViewModel() { Id = null };
            }
            return _CustomerForApplication;
        }

        public async Task<CustomerForApplication> UpdateCustomerForApplicationAsync(CustomerForApplication customerForApplicationToUpdate)
        {
            var _CustomerForApplicationToUpdate = await _dbContext.CustomerForApplications
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == customerForApplicationToUpdate.Id && x.ActiveFlag == true);

            if (_CustomerForApplicationToUpdate is null)
            {
                return new CustomerForApplication() { Id = 0 };
            }

            _CustomerForApplicationToUpdate.Name = customerForApplicationToUpdate.Name;
            _CustomerForApplicationToUpdate.Description = customerForApplicationToUpdate.Description;
            _CustomerForApplicationToUpdate.ActiveFlag = true;
            _CustomerForApplicationToUpdate.DateUpdated = DateTime.Now;

            _dbContext.CustomerForApplications.Update(_CustomerForApplicationToUpdate);
            await _dbContext.SaveChangesAsync();
            return _CustomerForApplicationToUpdate;
        }
    }
}

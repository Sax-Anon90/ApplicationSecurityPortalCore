using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.RoleGroups;
using ApplicationSecurity.Domain.IdentityAccessManagementDbContext;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.RoleGroups
{
    public class RoleGroupRepositoryAsync : IRoleGroupRepositoryAsync
    {
        private readonly ApplicationDevelopmentSecuritydbContext _dbContext;
        public RoleGroupRepositoryAsync(ApplicationDevelopmentSecuritydbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<RoleGroup> AddRoleGroupAsync(RoleGroup RoleGroupToAdd)
        {
            await _dbContext.RoleGroups.AddAsync(RoleGroupToAdd);
            await _dbContext.SaveChangesAsync();
            return RoleGroupToAdd;
        }

        public async Task<RoleGroup> DeleteRoleGroupAsync(RoleGroup RoleGroupToRemove)
        {
            var RoleGroupToDelete = await _dbContext
                .RoleGroups
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == RoleGroupToRemove.Id && x.ActiveFlag == true);

            if (RoleGroupToDelete is null)
            {
                return new RoleGroup() { Id = 0 };
            }

            RoleGroupToDelete.ActiveFlag = false;
            _dbContext.RoleGroups.Update(RoleGroupToDelete);
            await _dbContext.SaveChangesAsync();
            return RoleGroupToDelete;
        }

        public async Task<IEnumerable<RoleGroupViewModel>> GetAllRoleGroupsAsync()
        {
            var _RoleGroups = await (from RoleGroups in _dbContext.RoleGroups
                                     .Include(x => x.CustomerApplication)
                                     .AsSplitQuery()

                                     where RoleGroups.ActiveFlag == true
                                     && RoleGroups.CustomerApplication.ActiveFlag == true

                                     select new RoleGroupViewModel
                                     {
                                         Id = RoleGroups.Id,
                                         CustomerApplicationId = RoleGroups.CustomerApplicationId,
                                         Name = RoleGroups.Name,
                                         Description = RoleGroups.Description,
                                         ActiveFlag = RoleGroups.ActiveFlag,
                                         DateCreated = RoleGroups.DateCreated,
                                         DateUpdated = RoleGroups.DateUpdated,
                                         CustomerApplication = RoleGroups.CustomerApplication.Name

                                     }).AsNoTracking()
                                     .ToListAsync();
            if (_RoleGroups is null)
            {
                return Enumerable.Empty<RoleGroupViewModel>();
            }
            return _RoleGroups;
        }

        public async Task<RoleGroupViewModel> GetRoleGroupByRoleGroupIdAsync(int RoleGroupId)
        {
            var _RoleGroup = await (from RoleGroup in _dbContext.RoleGroups
                                    .Include(x => x.CustomerApplication)
                                    .AsSplitQuery()

                                    where RoleGroup.Id == RoleGroupId
                                    && RoleGroup.ActiveFlag == true

                                    select new RoleGroupViewModel
                                    {
                                        Id = RoleGroup.Id,
                                        CustomerApplicationId = RoleGroup.CustomerApplicationId,
                                        Name = RoleGroup.Name,
                                        Description = RoleGroup.Description,
                                        ActiveFlag = RoleGroup.ActiveFlag,
                                        DateCreated = RoleGroup.DateCreated,
                                        DateUpdated = RoleGroup.DateUpdated,
                                        CustomerApplication = RoleGroup.CustomerApplication.Name

                                    }).AsNoTracking()
                                    .FirstOrDefaultAsync();
            if (_RoleGroup is null)
            {
                return new RoleGroupViewModel() { Id = null };

            }
            return _RoleGroup;
        }

        public async Task<RoleGroup> UpdateRoleGroupAsync(RoleGroup RoleGroupToUpdate)
        {
            var roleGroupToUpdate = await _dbContext.RoleGroups
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == RoleGroupToUpdate.Id && x.ActiveFlag == true);

            if (roleGroupToUpdate is null)
            {
                return new RoleGroup() { Id = 0 };
            }

            roleGroupToUpdate.CustomerApplicationId = RoleGroupToUpdate.CustomerApplicationId;
            roleGroupToUpdate.Name = RoleGroupToUpdate.Name;
            roleGroupToUpdate.Description = RoleGroupToUpdate.Description;
            roleGroupToUpdate.ActiveFlag = true;
            roleGroupToUpdate.DateUpdated = DateTime.Now;

            _dbContext.RoleGroups.Update(roleGroupToUpdate);
            await _dbContext.SaveChangesAsync();
            return roleGroupToUpdate;
        }
    }
}

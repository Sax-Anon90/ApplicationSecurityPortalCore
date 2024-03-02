using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Roles;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Roles;
using ApplicationSecurity.Domain.IdentityAccessManagementDbContext;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.Roles
{
    public class RoleRepositoryAsync : IRoleRepositoryAsync
    {
        private readonly ApplicationDevelopmentSecuritydbContext _dbContext;
        public RoleRepositoryAsync(ApplicationDevelopmentSecuritydbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<Role> AddRoleAsync(Role RoleToAdd)
        {
            await _dbContext.Roles.AddAsync(RoleToAdd);
            await _dbContext.SaveChangesAsync();
            return RoleToAdd;
        }

        public async Task<Role> DeleteRoleAsync(Role RoleToRemove)
        {
            var _RoleToRemove = await _dbContext
                .Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == RoleToRemove.Id && x.ActiveFlag == true);

            if (_RoleToRemove is null)
            {
                return new Role() { Id = 0 };
            }

            _RoleToRemove.ActiveFlag = false;

            _dbContext.Roles.Update(_RoleToRemove);
            await _dbContext.SaveChangesAsync();
            return _RoleToRemove;
        }

        public async Task<IEnumerable<RolesViewModel>> GetAllRolesAsync()
        {
            var _roles = await (from roles in _dbContext.Roles
                                 .Include(x => x.RoleGroup)
                                 .AsSplitQuery()

                                where roles.ActiveFlag == true
                                && roles.RoleGroup.ActiveFlag == true

                                select new RolesViewModel
                                {
                                    Id = roles.Id,
                                    RoleGroupId = roles.RoleGroupId,
                                    Name = roles.Name,
                                    Description = roles.Description,
                                    ActiveFlag = roles.ActiveFlag,
                                    DateCreated = roles.DateCreated,
                                    DateUpdated = roles.DateUpdated,
                                    RoleGroup = roles.RoleGroup.Name

                                }).AsNoTracking()
                                 .ToListAsync();
            if (_roles is null)
            {
                return Enumerable.Empty<RolesViewModel>();
            }
            return _roles;
        }

        public async Task<RolesViewModel> GetRoleByRoleIdAsync(int RoleId)
        {
            var _role = await (from role in _dbContext.Roles
                               .Include(x => x.RoleGroup)
                               .AsSplitQuery()

                               where role.ActiveFlag == true
                               && role.Id == RoleId

                               select new RolesViewModel
                               {
                                   Id = role.Id,
                                   RoleGroupId = role.RoleGroupId,
                                   Name = role.Name,
                                   Description = role.Description,
                                   ActiveFlag = role.ActiveFlag,
                                   DateCreated = role.DateCreated,
                                   DateUpdated = role.DateUpdated,
                                   RoleGroup = role.RoleGroup.Name

                               }).AsNoTracking()
                               .FirstOrDefaultAsync();
            if (_role is null)
            {
                return new RolesViewModel() { Id = null };
            }
            return _role;
        }

        public async Task<Role> UpdateRoleAsync(Role RoleToUpdate)
        {
            var _roleToUpdate = await _dbContext.Roles
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == RoleToUpdate.Id && x.ActiveFlag == true);

            if (_roleToUpdate is null)
            {
                return new Role() { Id = 0 };
            }

            _roleToUpdate.RoleGroupId = RoleToUpdate.RoleGroupId;
            _roleToUpdate.Name = RoleToUpdate.Name;
            _roleToUpdate.Description = RoleToUpdate.Description;
            _roleToUpdate.ActiveFlag = true;
            _roleToUpdate.DateUpdated = DateTime.Now;

            _dbContext.Roles.Update(_roleToUpdate);
            await _dbContext.SaveChangesAsync();
            return _roleToUpdate;
        }
    }
}

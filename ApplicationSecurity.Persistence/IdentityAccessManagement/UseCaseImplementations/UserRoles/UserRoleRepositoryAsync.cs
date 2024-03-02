using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.UserRoles;
using ApplicationSecurity.Domain.IdentityAccessManagementDbContext;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.UserRoles
{
    public class UserRoleRepositoryAsync : IUserRoleRepositoryAsync
    {
        private readonly ApplicationDevelopmentSecuritydbContext _dbContext;
        public UserRoleRepositoryAsync(ApplicationDevelopmentSecuritydbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<UserRole> AddUserRoleAsync(UserRole UserRoleToAdd)
        {
            await _dbContext.UserRoles.AddAsync(UserRoleToAdd);
            await _dbContext.SaveChangesAsync();
            return UserRoleToAdd;
        }

        public async Task<UserRole> DeleteUserRoleAsync(UserRole UserRoleToRemove)
        {
            var _userRoleToRemove = await _dbContext.UserRoles
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == UserRoleToRemove.Id);

            if (_userRoleToRemove is null)
            {
                return new UserRole() { Id = 0 };
            }

            //_userRoleToRemove.ActiveFlag = false;
            _dbContext.UserRoles.Remove(_userRoleToRemove);
            await _dbContext.SaveChangesAsync();

            return _userRoleToRemove;
        }

        public async Task<IEnumerable<UserRolesViewModel>> GetAllUserRoleAsync()
        {
            var _userRoles = await (from userRole in _dbContext.UserRoles
                                   .Include(x => x.User)
                                   .Include(x => x.Role)
                                   .AsSplitQuery()

                                    where userRole.ActiveFlag == true
                                    && userRole.User.ActiveFlag == true
                                    && userRole.Role.ActiveFlag == true

                                    select new UserRolesViewModel
                                    {
                                        Id = userRole.Id,
                                        UserId = userRole.UserId,
                                        RoleId = userRole.RoleId,
                                        ActiveFlag = userRole.ActiveFlag,
                                        DateCreated = userRole.DateCreated,
                                        DateUpdated = userRole.DateUpdated,
                                        User = userRole.User.DisplayName,
                                        Role = userRole.Role.Name
                                    }).AsNoTracking()
                                   .ToListAsync();
            if (_userRoles is null)
            {
                return Enumerable.Empty<UserRolesViewModel>();
            }
            return _userRoles;
        }

        public async Task<IEnumerable<string>> GetAllUserRoleNamesByUserIdAsync(int UserId)
        {
            var _userRoles = await (from userRole in _dbContext.UserRoles
                                  .Include(x => x.User)
                                  .Include(x => x.Role)
                                  .AsSplitQuery()

                                    where userRole.ActiveFlag == true
                                    && userRole.UserId == UserId

                                    select new UserRolesViewModel
                                    {
                                        Id = userRole.Id,
                                        UserId = userRole.UserId,
                                        RoleId = userRole.RoleId,
                                        ActiveFlag = userRole.ActiveFlag,
                                        DateCreated = userRole.DateCreated,
                                        DateUpdated = userRole.DateUpdated,
                                        User = userRole.User.DisplayName,
                                        Role = userRole.Role.Name
                                    }).AsNoTracking()
                                   .ToListAsync();

            //Return all the user role names of the user

            return _userRoles.Select(x => x.Role).ToList();
        }

        public async Task<IEnumerable<UserRolesViewModel>> GetAllUserRolesByUserIdAsync(int userId)
        {
            var _userRoles = await (from userRole in _dbContext.UserRoles
                                    .Include(x => x.User)
                                    .Include(x => x.Role)
                                    .AsSplitQuery()

                                    where userRole.ActiveFlag == true
                                    && userRole.UserId == userId

                                    select new UserRolesViewModel
                                    {
                                        Id = userRole.Id,
                                        UserId = userRole.UserId,
                                        RoleId = userRole.RoleId,
                                        ActiveFlag = userRole.ActiveFlag,
                                        DateCreated = userRole.DateCreated,
                                        DateUpdated = userRole.DateUpdated,
                                        User = userRole.User.DisplayName,
                                        Role = userRole.Role.Name
                                    }).AsNoTracking()
                                    .ToListAsync();
            if (_userRoles is null)
            {
                return Enumerable.Empty<UserRolesViewModel>();
            }
            return _userRoles;
        }

        public async Task<UserRolesViewModel> GetUserRoleByUserRoleIdAsync(int UserRoleId)
        {
            var _userRole = await (from userRole in _dbContext.UserRoles
                                   .Include(x => x.User)
                                   .Include(x => x.Role)
                                   .AsSplitQuery()

                                   where userRole.ActiveFlag == true
                                   && userRole.Id == UserRoleId

                                   select new UserRolesViewModel
                                   {
                                       Id = userRole.Id,
                                       UserId = userRole.UserId,
                                       RoleId = userRole.RoleId,
                                       ActiveFlag = userRole.ActiveFlag,
                                       DateCreated = userRole.DateCreated,
                                       DateUpdated = userRole.DateUpdated,
                                       User = userRole.User.DisplayName,
                                       Role = userRole.Role.Name
                                   }).AsNoTracking()
                                  .FirstOrDefaultAsync();

            if (_userRole is null)
            {
                return new UserRolesViewModel();
            }
            return _userRole;
        }

        public async Task<UserRole> UpdateUserRoleAsync(UserRole UserRoleToUpdate)
        {
            var _userRoleToUpdate = await _dbContext.UserRoles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == UserRoleToUpdate.Id);

            _userRoleToUpdate.UserId = UserRoleToUpdate.UserId;
            _userRoleToUpdate.RoleId = UserRoleToUpdate.RoleId;
            _userRoleToUpdate.ActiveFlag = true;
            _userRoleToUpdate.DateUpdated = DateTime.Now;

            _dbContext.UserRoles.Update(_userRoleToUpdate);
            await _dbContext.SaveChangesAsync();
            return _userRoleToUpdate;
        }
    }
}

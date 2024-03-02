using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.UserTypes;
using ApplicationSecurity.Domain.IdentityAccessManagementDbContext;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.UserTypes
{
    public class UserTypeRepositoryAsync : IUserTypesRepositoryAsync
    {
        private readonly ApplicationDevelopmentSecuritydbContext _dbContext;
        public UserTypeRepositoryAsync(ApplicationDevelopmentSecuritydbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<UserType> AddUserTypeAsync(UserType userTypeToAdd)
        {
            await _dbContext.UserTypes.AddAsync(userTypeToAdd);
            await _dbContext.SaveChangesAsync();
            return userTypeToAdd;
        }

        public async Task<UserType> DeleteUserTypeAsync(UserType userTypeToRemove)
        {
            var _userTypeToRemove = await _dbContext.UserTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userTypeToRemove.Id);

            if (_userTypeToRemove is null)
            {
                return new UserType() { Id = 0 };
            }

            _userTypeToRemove.ActiveFlag = false;

            _dbContext.UserTypes.Update(_userTypeToRemove);
            await _dbContext.SaveChangesAsync();

            return _userTypeToRemove;
        }

        public async Task<IEnumerable<UserTypesViewModel>> GetAllUserTypesAsync()
        {
            var _userTypes = await (from userType in _dbContext.UserTypes

                                    where userType.ActiveFlag == true

                                    select new UserTypesViewModel
                                    {
                                        Id = userType.Id,
                                        Name = userType.Name,
                                        Description = userType.Description,
                                        ActiveFlag = userType.ActiveFlag,
                                        DateCreated = userType.DateCreated,
                                        DateUpdated = userType.DateUpdated,
                                    })
                                     .AsNoTracking()
                                     .ToListAsync();

            if (_userTypes is null)
            {
                return Enumerable.Empty<UserTypesViewModel>();
            }
            return _userTypes;
        }

        public async Task<UserTypesViewModel> GetUserTypeByUserTypeId(int UserTypeId)
        {
            var _userType = await (from userType in _dbContext.UserTypes

                                   where userType.ActiveFlag == true

                                   select new UserTypesViewModel
                                   {
                                       Id = userType.Id,
                                       Name = userType.Name,
                                       Description = userType.Description,
                                       ActiveFlag = userType.ActiveFlag,
                                       DateCreated = userType.DateCreated,
                                       DateUpdated = userType.DateUpdated,
                                   })
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();

            if (_userType is null)
            {
                return new UserTypesViewModel() { Id = null };
            }
            return _userType;
        }

        public async Task<UserType> UpdateUserTypeAsync(UserType userTypeToUpdate)
        {
            var _userTypeToUpdate = await _dbContext.UserTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userTypeToUpdate.Id && x.ActiveFlag == true);

            if (_userTypeToUpdate is null)
            {
                return new UserType() { Id = 0 };
            }

            _userTypeToUpdate.Name = userTypeToUpdate.Name;
            _userTypeToUpdate.Description = userTypeToUpdate.Description;
            _userTypeToUpdate.ActiveFlag = true;
            _userTypeToUpdate.DateUpdated = DateTime.Now;

            _dbContext.UserTypes.Update(_userTypeToUpdate);
            await _dbContext.SaveChangesAsync();
            return _userTypeToUpdate;
        }
    }
}

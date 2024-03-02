using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Users;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.Users;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.UserRoles;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Users;
using ApplicationSecurity.Domain.IdentityAccessManagementDbContext;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.Users
{
    public class UsersRepositoryAsync : IUsersRepositoryAsync
    {
        private readonly ApplicationDevelopmentSecuritydbContext _dbContext;
        public UsersRepositoryAsync(ApplicationDevelopmentSecuritydbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<User> AddUserAsync(User userToAdd)
        {
            await _dbContext.Users.AddAsync(userToAdd);
            await _dbContext.SaveChangesAsync();
            return userToAdd; throw new NotImplementedException();
        }

        public async Task<User> DeleteUserAsync(User UserToRemove)
        {
            var _userToRemove = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == UserToRemove.Id && x.ActiveFlag == true);

            if (_userToRemove is null)
            {
                return new User() { Id = 0 };
            }

            _userToRemove.ActiveFlag = false;
            _userToRemove.DateInactive = DateTime.Now;
            _dbContext.Users.Update(_userToRemove);
            await _dbContext.SaveChangesAsync();
            return _userToRemove;
        }

        public async Task<IEnumerable<UsersViewModel>> GetAllUsersAsync()
        {
            var _users = await (from users in _dbContext.Users
                               .Include(x => x.UserType)
                               .AsSplitQuery()

                                where users.ActiveFlag == true

                                select new UsersViewModel
                                {
                                    Id = users.Id,
                                    FirstName = users.FirstName,
                                    LastName = users.LastName,
                                    UserName = users.UserName,
                                    DisplayName = users.DisplayName,
                                    TelNo = users.TelNo,
                                    MobileNo = users.MobileNo,
                                    Email = users.Email,
                                    IdNumber = users.IdNumber,
                                    ActiveFlag = users.ActiveFlag,
                                    UserCode = users.UserCode,
                                    DateOfBirth = users.DateOfBirth,
                                    UserTypeId = users.UserTypeId,
                                    DateCreated = users.DateCreated,
                                    DateUpdated = users.DateUpdated,
                                    DateInactive = users.DateInactive,
                                    PasswordResetExpiryDate = users.PasswordResetExpiryDate,
                                    PasswordSetUpExpiryDate = users.PasswordSetUpExpiryDate,
                                    UserType = users.UserType.Name

                                }).AsNoTracking()
                               .ToListAsync();

            if (_users is null)
            {
                return Enumerable.Empty<UsersViewModel>();
            }
            return _users;
        }

        public async Task<UsersViewModel> GetUserByEmailAndPasswordHashAsync(UserAuthDetailsModel userAuthDeatilsModel)
        {
            var _user = await (from users in _dbContext.Users
                               .Include(x => x.UserType)
                               .AsSplitQuery()

                               where (users.Email == userAuthDeatilsModel.Email || userAuthDeatilsModel.Email == users.UserName)
                                && users.PasswordHash == userAuthDeatilsModel.Password
                                &&
                               users.ActiveFlag == true

                               select new UsersViewModel
                               {
                                   Id = users.Id,
                                   FirstName = users.FirstName,
                                   LastName = users.LastName,
                                   UserName = users.UserName,
                                   DisplayName = users.DisplayName,
                                   TelNo = users.TelNo,
                                   MobileNo = users.MobileNo,
                                   Email = users.Email,
                                   IdNumber = users.IdNumber,
                                   DateOfBirth = users.DateOfBirth,
                                   UserTypeId = users.UserTypeId,
                                   ActiveFlag = users.ActiveFlag,
                                   UserCode = users.UserCode,
                                   DateCreated = users.DateCreated,
                                   DateUpdated = users.DateUpdated,
                                   DateInactive = users.DateInactive,
                                   PasswordResetExpiryDate = users.PasswordResetExpiryDate,
                                   PasswordSetUpExpiryDate = users.PasswordSetUpExpiryDate,
                                   UserType = users.UserType.Name

                               }).AsNoTracking()
                                .FirstOrDefaultAsync();

            if (_user is null)
            {
                return new UsersViewModel() { Id = null };
            }
            return _user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email && x.ActiveFlag == true);

            if (user is null)
            {
                return new User() { Id = 0 };
            }
            return user;
        }

        public async Task<UsersViewModel> GetUserByUserCodeAsync(string UserCode)
        {
            var _user = await (from users in _dbContext.Users
                              .Include(x => x.UserType)
                              .AsSplitQuery()

                               where users.ActiveFlag == true
                               && users.UserCode == UserCode

                               select new UsersViewModel
                               {
                                   Id = users.Id,
                                   FirstName = users.FirstName,
                                   LastName = users.LastName,
                                   UserName = users.UserName,
                                   DisplayName = users.DisplayName,
                                   TelNo = users.TelNo,
                                   MobileNo = users.MobileNo,
                                   Email = users.Email,
                                   IdNumber = users.IdNumber,
                                   DateOfBirth = users.DateOfBirth,
                                   UserTypeId = users.UserTypeId,
                                   DateCreated = users.DateCreated,
                                   ActiveFlag = users.ActiveFlag,
                                   UserCode = users.UserCode,
                                   DateUpdated = users.DateUpdated,
                                   DateInactive = users.DateInactive,
                                   PasswordResetExpiryDate = users.PasswordResetExpiryDate,
                                   PasswordSetUpExpiryDate = users.PasswordSetUpExpiryDate,
                                   UserType = users.UserType.Name,

                               }).AsNoTracking()
                               .FirstOrDefaultAsync();

            if (_user is null)
            {
                return new UsersViewModel() { Id = null };
            }
            return _user;
        }

        public async Task<UsersViewModel> GetUserByUserIdAsync(int userId)
        {
            var _user = await (from users in _dbContext.Users
                               .Include(x => x.UserType)
                               .AsSplitQuery()

                               where users.ActiveFlag == true
                               && users.Id == userId

                               select new UsersViewModel
                               {
                                   Id = users.Id,
                                   FirstName = users.FirstName,
                                   LastName = users.LastName,
                                   UserName = users.UserName,
                                   DisplayName = users.DisplayName,
                                   TelNo = users.TelNo,
                                   MobileNo = users.MobileNo,
                                   Email = users.Email,
                                   IdNumber = users.IdNumber,
                                   DateOfBirth = users.DateOfBirth,
                                   UserTypeId = users.UserTypeId,
                                   DateCreated = users.DateCreated,
                                   ActiveFlag = users.ActiveFlag,
                                   UserCode = users.UserCode,
                                   DateUpdated = users.DateUpdated,
                                   DateInactive = users.DateInactive,
                                   PasswordResetExpiryDate = users.PasswordResetExpiryDate,
                                   PasswordSetUpExpiryDate = users.PasswordSetUpExpiryDate,
                                   UserType = users.UserType.Name,

                               }).AsNoTracking()
                                .FirstOrDefaultAsync();

            if (_user is null)
            {
                return new UsersViewModel() { Id = null };
            }
            return _user;
        }

        public async Task<User> UpdateUserAsync(User userToUpdate)
        {
            var _userToUpdate = await _dbContext.Users
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == userToUpdate.Id && x.ActiveFlag == true);

            if (_userToUpdate is null)
            {
                return new User() { Id = 0 };
            }

            _userToUpdate.FirstName = userToUpdate.FirstName;
            _userToUpdate.LastName = userToUpdate.LastName;
            _userToUpdate.UserName = userToUpdate.UserName;
            _userToUpdate.DisplayName = userToUpdate.DisplayName;
            _userToUpdate.TelNo = userToUpdate.TelNo;
            _userToUpdate.MobileNo = userToUpdate.MobileNo;
            _userToUpdate.DateOfBirth = userToUpdate.DateOfBirth;
            _userToUpdate.Email = userToUpdate.Email;
            _userToUpdate.IdNumber = userToUpdate.IdNumber;
            _userToUpdate.UserTypeId = userToUpdate.UserTypeId;
            _userToUpdate.ActiveFlag = true;
            _userToUpdate.DateUpdated = DateTime.Now;


            _dbContext.Users.Update(_userToUpdate);
            await _dbContext.SaveChangesAsync();
            return _userToUpdate;
        }
    }
}

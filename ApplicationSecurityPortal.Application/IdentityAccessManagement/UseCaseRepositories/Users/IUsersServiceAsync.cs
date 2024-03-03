using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.Users
{
    public interface IUsersServiceAsync
    {
        Task<Response<IEnumerable<UsersViewModel>>> GetAllUsersAsync();
        Task<Response<UsersViewModel>> GetUserByUserIdAsync(int UserId);
        Task<Response<UsersViewModel>> CreateUserAsync(UsersInputModel usersInputModel);
        Task<Response<UsersViewModel>> UpdateUserAsync(UsersUpdateModel usersUpdateModel);
        Task<Response<UsersViewModel>> DeleteUserAsync(int UserId);
        Task<Response<UsersViewModel>> GetUserByUserCodeAsync(string UserCode);
    }
}

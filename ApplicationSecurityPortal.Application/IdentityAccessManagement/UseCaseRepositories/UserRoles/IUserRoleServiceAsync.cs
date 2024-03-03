using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.UserRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles
{
    public interface IUserRoleServiceAsync
    {
        Task<Response<IEnumerable<UserRolesViewModel>>> GetUserRolesByUserIdAsync(int UserId);
        Task<Response<UserRolesViewModel>> CreateUserRoleAsync(UserRoleInputModel userRoleInputModel);
        Task<Response<UserRolesViewModel>> DeleteUserRoleAsync(int UserRoleId);
    }
}

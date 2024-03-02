using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.UserRoles;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles
{
    public interface IUserRoleRepositoryAsync
    {
        Task<UserRolesViewModel> GetUserRoleByUserRoleIdAsync(int UserRoleId);
        Task<IEnumerable<UserRolesViewModel>> GetAllUserRoleAsync();
        Task<IEnumerable<UserRolesViewModel>> GetAllUserRolesByUserIdAsync(int userId);
        Task<UserRole> AddUserRoleAsync(UserRole UserRoleToAdd);
        Task<UserRole> UpdateUserRoleAsync(UserRole UserRoleToUpdate);
        Task<UserRole> DeleteUserRoleAsync(UserRole UserRoleToRemove);

        Task<IEnumerable<string>> GetAllUserRoleNamesByUserIdAsync(int UserId);
    }
}

using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Roles;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Roles
{
    public interface IRoleRepositoryAsync
    {
        Task<RolesViewModel> GetRoleByRoleIdAsync(int RoleId);
        Task<IEnumerable<RolesViewModel>> GetAllRolesAsync();
        Task<Role> AddRoleAsync(Role RoleToAdd);
        Task<Role> UpdateRoleAsync(Role RoleToUpdate);
        Task<Role> DeleteRoleAsync(Role RoleToRemove);
    }
}

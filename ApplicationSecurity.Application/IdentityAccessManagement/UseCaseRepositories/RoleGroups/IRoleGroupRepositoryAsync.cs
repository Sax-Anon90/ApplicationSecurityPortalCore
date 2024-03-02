using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.RoleGroups;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups
{
    public interface IRoleGroupRepositoryAsync
    {
        Task<RoleGroupViewModel> GetRoleGroupByRoleGroupIdAsync(int RoleGroupId);
        Task<IEnumerable<RoleGroupViewModel>> GetAllRoleGroupsAsync();
        Task<RoleGroup> AddRoleGroupAsync(RoleGroup RoleGroupToAdd);
        Task<RoleGroup> UpdateRoleGroupAsync(RoleGroup RoleGroupToUpdate);
        Task<RoleGroup> DeleteRoleGroupAsync(RoleGroup RoleGroupToRemove);
    }
}

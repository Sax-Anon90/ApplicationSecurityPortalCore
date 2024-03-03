using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.RoleGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups
{
    public interface IRoleGroupsServiceAsync
    {
        Task<Response<IEnumerable<RoleGroupsViewModel>>> GetAllRoleGroupsAsync();
        Task<Response<RoleGroupsViewModel>> CreateRoleGroupAsync(RoleGroupsInputModel roleGroupsInputModel);
        Task<Response<RoleGroupsViewModel>> UpdateRoleGroupAsync(RoleGroupsUpdateModel roleGroupsUpdateModel);
        Task<Response<RoleGroupsViewModel>> DeleteRoleGroupAsync(int RoleGroupId);
    }
}

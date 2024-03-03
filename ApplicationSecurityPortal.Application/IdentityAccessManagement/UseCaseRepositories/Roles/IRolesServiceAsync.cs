using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.Roles
{
    public interface IRolesServiceAsync
    {
        Task<Response<IEnumerable<RolesViewModel>>> GetAllRolesAsync();
        Task<Response<RolesViewModel>> AddRoleAsync(RolesInputModel rolesInputModel);
        Task<Response<RolesViewModel>> UpdateRoleAsync(RolesUpdateModel rolesUpdateModel);
        Task<Response<RolesViewModel>> DeleteRoleAsync(int RoleId);
    }
}

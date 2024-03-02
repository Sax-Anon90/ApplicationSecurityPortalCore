using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.RoleGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.CustomerApplications
{
    public class CustomerApplicationRoleGroupRoles
    {
        public int CustomerApplicationId { get; set; }
        public string CustomerApplicationName { get; set; }
        public IEnumerable<RoleGroupsWithRolesViewModel> RoleGroupWithRoles { get; set; }
    }
}

using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.RoleGroups
{
    public class RoleGroupsWithRolesViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool ActiveFlag { get; set; }
        public int CustomerApplicationId { get; set; }

        public IEnumerable<RolesViewModel> Roles { get; set; }
    }
}

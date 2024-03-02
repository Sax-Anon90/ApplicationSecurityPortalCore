using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.Roles
{
    public class RoleModel
    {
        public int RoleGroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

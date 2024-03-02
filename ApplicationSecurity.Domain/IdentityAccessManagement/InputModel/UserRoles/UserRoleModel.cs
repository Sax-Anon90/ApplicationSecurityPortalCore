using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.UserRoles
{
    public class UserRoleModel
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.UserRoles
{
    public class UserRoleInputModel
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}

using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.Roles
{
    public class RolesUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public int RoleGroupId { get; set; }
    }
}

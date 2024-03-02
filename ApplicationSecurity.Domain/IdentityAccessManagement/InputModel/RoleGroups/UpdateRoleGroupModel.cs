using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.RoleGroups
{
    public class UpdateRoleGroupModel
    {
        public int Id { get; set; }
        public int CustomerApplicationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

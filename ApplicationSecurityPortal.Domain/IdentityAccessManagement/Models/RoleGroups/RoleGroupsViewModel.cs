using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.RoleGroups
{
    public class RoleGroupsViewModel : BaseModel
    {
        public int? Id { get; set; }
        public bool ActiveFlag { get; set; }
        public int CustomerApplicationId { get; set; }
        public string? CustomerApplication { get; set; }
        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}

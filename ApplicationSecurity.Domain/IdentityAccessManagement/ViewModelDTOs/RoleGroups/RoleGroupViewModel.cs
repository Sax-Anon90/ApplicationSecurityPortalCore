using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.RoleGroups
{
    public class RoleGroupViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool ActiveFlag { get; set; }
        public int CustomerApplicationId { get; set; }
        public string? CustomerApplication { get; set; }
        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
        public virtual IEnumerable<RolesViewModel> Roles { get; set; } = new List<RolesViewModel>();
    }
}

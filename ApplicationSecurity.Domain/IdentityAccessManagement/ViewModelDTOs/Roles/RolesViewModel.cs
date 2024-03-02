using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Roles
{
    public class RolesViewModel
    {
        public int? Id { get; set; }

        public int RoleGroupId { get; set; }
        public string? RoleGroup { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool ActiveFlag { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}

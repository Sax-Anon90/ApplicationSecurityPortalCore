using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.UserTypes
{
    public class UserTypesViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool ActiveFlag { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}

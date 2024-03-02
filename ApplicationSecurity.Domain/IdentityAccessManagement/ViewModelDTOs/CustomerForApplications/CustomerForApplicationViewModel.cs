using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.CustomerForApplications
{
    public class CustomerForApplicationViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool ActiveFlag { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public DateTime? DateInactive { get; set; }
    }
}

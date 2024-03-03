using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.CustomerForApplications
{
    public class CustomerForApplicationsViewModel : BaseModel
    {
        public int? Id { get; set; }

        public bool? ActiveFlag { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public DateTime? DateInactive { get; set; }
    }
}

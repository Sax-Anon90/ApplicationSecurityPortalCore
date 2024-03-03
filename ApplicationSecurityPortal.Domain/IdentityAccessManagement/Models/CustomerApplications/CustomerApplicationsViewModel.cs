using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.CustomerApplications
{
    public class CustomerApplicationsViewModel : BaseModel
    {
        public int? Id { get; set; }

        public int CustomerForApplicationId { get; set; }

        public string? CustomerForApplication { get; set; }

        public bool ActiveFlag { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

    }
}

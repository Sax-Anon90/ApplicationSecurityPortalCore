using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.CustomerApplications
{
    public class CustomerApplicationsInputModel : BaseModel 
    {
        public int? CustomerForApplicationId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.CustomerApplications
{
    public class UpdateCustomerApplicationsModel
    {
        public int Id { get; set; }
        public int CustomerForApplicationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

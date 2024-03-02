using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.ApiKeys
{
    public class ApiKeyInputModel
    {
        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ExpiryDate { get; set; }
    }
}

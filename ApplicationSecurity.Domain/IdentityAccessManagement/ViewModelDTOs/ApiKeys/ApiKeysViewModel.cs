using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.ApiKeys
{
    public class ApiKeysViewModel
    {
        public int? Id { get; set; }

        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ExpiryDate { get; set; }

        public bool ActiveFlag { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public DateTime? DateInactive { get; set; }
    }
}

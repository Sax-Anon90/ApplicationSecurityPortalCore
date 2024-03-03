using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Infrustructure.BaseApiService
{
    public class ApiService
    {
        private readonly IConfiguration _configuration;
        public ApiService(IConfiguration _configuration)
        {
            this._configuration = _configuration;
            BaseApiUrl = _configuration["ApiService:ApplicationSecurityApiUri"].ToString();

            AuthenticationServiceEndpoint = _configuration["ApiService:AuthenticationServiceEndpoint"].ToString();
            CustomerForApplicationEndpoint = _configuration["ApiService:CustomerForApplicationEndpoint"].ToString();

            CustomerApplicationEndpoint = _configuration["ApiService:CustomerApplicationEndpoint"].ToString();
            RoleGroupsEndpoint = _configuration["ApiService:RoleGroupsEndpoint"].ToString();

            RolesEndpoint = _configuration["ApiService:RolesEndpoint"].ToString();
            UserTypesEndpoint = _configuration["ApiService:UserTypesEndpoint"].ToString();

            UsersEndpoint = _configuration["ApiService:UsersEndpoint"].ToString();
            UserRolesEndpoint = _configuration["ApiService:UserRolesEndpoint"].ToString();
        }

        public string BaseApiUrl { get; set; } = "";
        public string AuthenticationServiceEndpoint { get; set; }
        public string CustomerForApplicationEndpoint { get; set; }
        public string CustomerApplicationEndpoint { get; set; }
        public string RoleGroupsEndpoint { get; set; }
        public string RolesEndpoint { get; set; }
        public string UserTypesEndpoint { get; set; }
        public string UsersEndpoint { get; set; }
        public string UserRolesEndpoint { get; set; }
    }
}

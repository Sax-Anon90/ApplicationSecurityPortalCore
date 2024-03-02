using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.Users
{
    public class UserPasswordSetUpModel
    {
        public string UserEmail { get; set; }
        public string NewUserPassword { get; set; }
    }
}

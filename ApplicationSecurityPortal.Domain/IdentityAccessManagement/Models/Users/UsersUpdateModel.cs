using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.Users
{
    public class UsersUpdateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? UserName { get; set; }

        public string? DisplayName { get; set; }


        public string? TelNo { get; set; }

        public string? MobileNo { get; set; }

        public string Email { get; set; }

        public string? IdNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public int UserTypeId { get; set; }
    }
}

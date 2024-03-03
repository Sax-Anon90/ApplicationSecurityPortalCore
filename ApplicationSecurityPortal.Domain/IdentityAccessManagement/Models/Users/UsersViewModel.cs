using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.Users
{
    public class UsersViewModel
    {
        public int? Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? UserName { get; set; }

        public string? DisplayName { get; set; }

        public string? TelNo { get; set; }

        public string? MobileNo { get; set; }

        public string Email { get; set; } = null!;

        public string? IdNumber { get; set; }
        public string? UserCode { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public int UserTypeId { get; set; }
        public string? UserType { get; set; }
        public bool ActiveFlag { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public DateTime? DateInactive { get; set; }

        public DateTime? PasswordSetUpExpiryDate { get; set; }

        public DateTime? PasswordResetExpiryDate { get; set; }
    }
}

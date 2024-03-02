﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.Users
{
    public class UsersModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string TelNo { get; set; }

        public string MobileNo { get; set; }
        public bool ActiveFlag { get; set; }

        public string Email { get; set; }

        public string IdNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public int UserTypeId { get; set; }
    }
}

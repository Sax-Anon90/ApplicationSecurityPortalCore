using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.PasswordService
{
    public interface IPasswordService
    {
        string GetPasswordHash(string password);
    }
}

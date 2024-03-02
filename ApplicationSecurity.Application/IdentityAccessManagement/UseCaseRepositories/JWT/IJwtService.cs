using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.JWT
{
    public interface IJwtService
    {
        string GenerateJwtTokenForUserAsync(List<string> userRoles, UsersViewModel user);
    }
}

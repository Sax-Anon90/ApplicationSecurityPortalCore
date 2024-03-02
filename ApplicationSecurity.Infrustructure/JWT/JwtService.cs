using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.JWT;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Infrustructure.JWT
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }
        public string GenerateJwtTokenForUserAsync(List<string> userRoles, UsersViewModel user)
        {
            var userRoleClaims = new List<Claim>();

            if (userRoles.Count > 0)
            {
                foreach (var userRole in userRoles)
                {
                    userRoleClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,  user.Email),
                new Claim("DisplayName", user.DisplayName)
            }.Union(userRoleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                                            issuer: _configuration["JwtSettings:Issuer"],
                                            audience: _configuration["JwtSettings:Audience"],
                                            claims: claims,
                                            expires: DateTime.Now.AddHours(24),
                                            signingCredentials: signingCredentials);


            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}

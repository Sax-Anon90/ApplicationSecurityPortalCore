using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.JWT;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.PasswordService;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Users;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.Users;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Authentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.Users.Commands
{
    public class AuthenticateUserCommand : IRequest<Response<AuthUserResponse>>
    {
        public UserAuthDetailsModel userAuthDetailsModel { get; set; }
        public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, Response<AuthUserResponse>>
        {
            private readonly IJwtService _jwtService;
            private readonly IUserRoleRepositoryAsync _userRoleRepositoryAsync;
            private readonly IUsersRepositoryAsync _usersRepositoryAsync;
            private readonly IPasswordService _passwordService;
            public AuthenticateUserCommandHandler(IJwtService _jwtService,
                IUserRoleRepositoryAsync _userRoleRepositoryAsync,
                IUsersRepositoryAsync _usersRepositoryAsync,
                IPasswordService _passwordService)
            {
                this._jwtService = _jwtService;
                this._userRoleRepositoryAsync = _userRoleRepositoryAsync;
                this._usersRepositoryAsync = _usersRepositoryAsync;
                this._passwordService = _passwordService;
            }

            public async Task<Response<AuthUserResponse>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
            {
                var _userPasswordHash = _passwordService.GetPasswordHash(request.userAuthDetailsModel.Password);

                var _user = await _usersRepositoryAsync.GetUserByEmailAndPasswordHashAsync(new UserAuthDetailsModel()
                {
                    Email = request.userAuthDetailsModel.Email,
                    Password = _userPasswordHash
                });

                if (_user.Id == null)
                {
                    return new Response<AuthUserResponse>()
                    {
                        Succeeded = false,
                        Message = "Authentication failed. Invalid Email or Password",
                        Data = null
                    };
                }

                var _userRoles = await _userRoleRepositoryAsync.GetAllUserRoleNamesByUserIdAsync((int)_user.Id);
                var UserJwtAccessToken = _jwtService.GenerateJwtTokenForUserAsync(_userRoles.ToList(), _user);

                return new Response<AuthUserResponse>()
                {
                    Succeeded = true,
                    Message = $"User {request.userAuthDetailsModel.Email} successfully Authenticated",
                    Data = new AuthUserResponse()
                    {
                        UserId = (int)_user.Id,
                        UserEmail = _user.Email,
                        DisplayName = _user.DisplayName,
                        JwtAccessToken = UserJwtAccessToken
                    }
                };

            }
        }
    }
}

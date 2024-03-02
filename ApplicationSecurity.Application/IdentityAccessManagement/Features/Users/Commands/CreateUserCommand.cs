using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Users;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.Users;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<Response<User>>
    {
        public UsersModel UserToAdd { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<User>>
        {
            private readonly IUsersRepositoryAsync _usersRepositoryAsync;
            public CreateUserCommandHandler(IUsersRepositoryAsync _usersRepositoryAsync)
            {
                this._usersRepositoryAsync = _usersRepositoryAsync;
            }
            public async Task<Response<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var _userToCreate = new User()
                {
                    FirstName = request.UserToAdd.FirstName,
                    LastName = request.UserToAdd.LastName,
                    UserName = request.UserToAdd.UserName,
                    DisplayName = request.UserToAdd.DisplayName,
                    TelNo = request.UserToAdd.TelNo,
                    MobileNo = request.UserToAdd.MobileNo,
                    Email = request.UserToAdd.Email,
                    IdNumber = request.UserToAdd.IdNumber,
                    DateOfBirth = request.UserToAdd.DateOfBirth,
                    UserTypeId = request.UserToAdd.UserTypeId,
                    UserCode = $"{Guid.NewGuid().ToString()}",
                    ActiveFlag = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,

                };

                var createdUser = await _usersRepositoryAsync.AddUserAsync(_userToCreate);

                //To Make Sure that the password hashes are not returned in the api response
                createdUser.PasswordHash = null;
                createdUser.ResetPasswordHash = null;

                return new Response<User>()
                {
                    Succeeded = true,
                    Message = "User created successfully",
                    Data = createdUser
                };

            }
        }
    }
}

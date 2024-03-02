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
    public class UpdateUserCommand : IRequest<Response<User>>
    {
        public UpdateUsersModel userToUpdate { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<User>>
        {
            private readonly IUsersRepositoryAsync _usersRepositoryAsync;
            public UpdateUserCommandHandler(IUsersRepositoryAsync _usersRepositoryAsync)
            {
                this._usersRepositoryAsync = _usersRepositoryAsync;
            }
            public async Task<Response<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var _userToUpdate = new User()
                {
                    Id = request.userToUpdate.Id,
                    FirstName = request.userToUpdate.FirstName,
                    LastName = request.userToUpdate.LastName,
                    UserName = request.userToUpdate.UserName,
                    DisplayName = request.userToUpdate.DisplayName,
                    TelNo = request.userToUpdate.TelNo,
                    MobileNo = request.userToUpdate.MobileNo,
                    Email = request.userToUpdate.Email,
                    IdNumber = request.userToUpdate.IdNumber,
                    DateOfBirth = request.userToUpdate.DateOfBirth,
                    UserTypeId = request.userToUpdate.UserTypeId
                };

                var _userToUpdateResponse = await _usersRepositoryAsync.UpdateUserAsync(_userToUpdate);

                if (_userToUpdateResponse.Id == 0)
                {
                    return new Response<User>()
                    {
                        Succeeded = true,
                        Message = $"User not found to update",
                        Data = null
                    };
                }

                //To Make Sure that the password hashes are not returned in the api response
                _userToUpdateResponse.PasswordHash = null;
                _userToUpdateResponse.ResetPasswordHash = null;

                return new Response<User>()
                {
                    Succeeded = true,
                    Message = $"User with Id updated successfully",
                    Data = _userToUpdateResponse
                };
            }
        }
    }
}

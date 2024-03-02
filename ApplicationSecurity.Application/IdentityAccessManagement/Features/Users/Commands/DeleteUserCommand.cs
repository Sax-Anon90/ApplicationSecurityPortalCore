using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Users;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.Users.Commands
{
    public class DeleteUserCommand : IRequest<Response<User>>
    {
        public int UserId { get; set; }
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<User>>
        {
            private readonly IUsersRepositoryAsync _usersRepositoryAsync;
            public DeleteUserCommandHandler(IUsersRepositoryAsync _usersRepositoryAsync)
            {
                this._usersRepositoryAsync = _usersRepositoryAsync;
            }
            public async Task<Response<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var _userToMakeInactive = new User()
                {
                    Id = request.UserId
                };

                var _userToMakeInactiveResponse = await _usersRepositoryAsync.DeleteUserAsync(_userToMakeInactive);

                if (_userToMakeInactiveResponse.Id == 0)
                {
                    return new Response<User>()
                    {
                        Succeeded = false,
                        Message = $"User  not found to make inactive",
                        Data = _userToMakeInactiveResponse
                    };
                }

                return new Response<User>()
                {
                    Succeeded = true,
                    Message = $"User is now Inactive",
                    Data = _userToMakeInactiveResponse
                };
            }
        }
    }
}

using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.UserRoles;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.UserRoles.Commands
{
    public class CreateUserRoleCommand : IRequest<Response<UserRole>>
    {
        public UserRoleModel userRoleToAdd { get; set; }

        public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, Response<UserRole>>
        {
            private readonly IUserRoleRepositoryAsync _userRoleRepositoryAsync;
            public CreateUserRoleCommandHandler(IUserRoleRepositoryAsync _userRoleRepositoryAsync)
            {
                this._userRoleRepositoryAsync = _userRoleRepositoryAsync;
            }
            public async Task<Response<UserRole>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
            {
                var _userRoleToAdd = new UserRole()
                {
                    UserId = request.userRoleToAdd.UserId,
                    RoleId = request.userRoleToAdd.RoleId,
                    ActiveFlag = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                };

                var createdUserRole = await _userRoleRepositoryAsync.AddUserRoleAsync(_userRoleToAdd);

                return new Response<UserRole>()
                {
                    Succeeded = true,
                    Message = "User Role successfully created",
                    Data = createdUserRole
                };
            }
        }
    }
}

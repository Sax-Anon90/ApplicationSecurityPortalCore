using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.UserRoles.Commands
{
    public class DeleteUserRoleCommand : IRequest<Response<UserRole>>
    {
        public int UserRoleId { get; set; }
        public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, Response<UserRole>>
        {
            private readonly IUserRoleRepositoryAsync _userRoleRepositoryAsync;
            public DeleteUserRoleCommandHandler(IUserRoleRepositoryAsync _userRoleRepositoryAsync)
            {
                this._userRoleRepositoryAsync = _userRoleRepositoryAsync;
            }
            public async Task<Response<UserRole>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
            {
                var UserRoleToDelete = new UserRole { Id = request.UserRoleId };

                var UserRoleToDeleteResponse = await _userRoleRepositoryAsync.DeleteUserRoleAsync(UserRoleToDelete);

                if (UserRoleToDeleteResponse.Id == 0)
                {
                    return new Response<UserRole>()
                    {
                        Succeeded = false,
                        Message = $"User Role not found to delete",
                        Data = UserRoleToDeleteResponse
                    };
                }

                return new Response<UserRole>()
                {
                    Succeeded = true,
                    Message = $"User Role has been removed",
                };
            }
        }
    }
}

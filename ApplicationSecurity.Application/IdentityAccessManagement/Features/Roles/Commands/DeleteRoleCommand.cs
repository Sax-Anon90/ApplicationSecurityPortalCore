using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Roles;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.Roles.Commands
{
    public class DeleteRoleCommand : IRequest<Response<Role>>
    {
        public int RoleId { get; set; }
        public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Response<Role>>
        {
            private readonly IRoleRepositoryAsync _roleRepositoryAsync;
            public DeleteRoleCommandHandler(IRoleRepositoryAsync _roleRepositoryAsync)
            {
                this._roleRepositoryAsync = _roleRepositoryAsync;
            }
            public async Task<Response<Role>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                var RoleToMakeInactive = new Role { Id = request.RoleId };

                var RoleToMakeInactiveResponse = await _roleRepositoryAsync.DeleteRoleAsync(RoleToMakeInactive);

                if (RoleToMakeInactiveResponse.Id == 0)
                {
                    return new Response<Role>()
                    {
                        Succeeded = false,
                        Message = $"Role not found to make inactive",
                        Data = null
                    };
                }

                return new Response<Role>()
                {
                    Succeeded = true,
                    Message = $"Role is now inactive",
                    Data = RoleToMakeInactiveResponse
                };

            }
        }
    }
}

using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Roles;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.Roles;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.Roles.Commands
{
    public class UpdateRoleCommand : IRequest<Response<Role>>
    {
        public UpdateRoleModel roleToUpdate { get; set; }
        public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Response<Role>>
        {
            private readonly IRoleRepositoryAsync _roleRepositoryAsync;
            public UpdateRoleCommandHandler(IRoleRepositoryAsync _roleRepositoryAsync)
            {
                this._roleRepositoryAsync = _roleRepositoryAsync;
            }
            public async Task<Response<Role>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
            {
                var _roleToUpdate = new Role()
                {
                    Id = request.roleToUpdate.Id,
                    RoleGroupId = request.roleToUpdate.RoleGroupId,
                    Name = request.roleToUpdate.Name,
                    Description = request.roleToUpdate.Description
                };

                var _roleToUpdateResponse = await _roleRepositoryAsync.UpdateRoleAsync(_roleToUpdate);

                if (_roleToUpdateResponse.Id == 0)
                {
                    return new Response<Role>()
                    {
                        Succeeded = false,
                        Message = $"Role not found to update",
                        Data = null
                    };
                }

                return new Response<Role>()
                {
                    Succeeded = true,
                    Message = $"Role Updated successfully",
                    Data = _roleToUpdateResponse
                };
            }
        }

    }
}

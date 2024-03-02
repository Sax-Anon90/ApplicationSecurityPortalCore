using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.RoleGroups;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.RoleGroups.Commands
{
    public class UpdateRoleGroupCommand : IRequest<Response<RoleGroup>>
    {
        public UpdateRoleGroupModel roleGroupToUpdate { get; set; }
        public class UpdateRoleGroupCommandHandler : IRequestHandler<UpdateRoleGroupCommand, Response<RoleGroup>>
        {
            private readonly IRoleGroupRepositoryAsync _roleGroupRepositoryAsync;
            public UpdateRoleGroupCommandHandler(IRoleGroupRepositoryAsync _roleGroupRepositoryAsync)
            {
                this._roleGroupRepositoryAsync = _roleGroupRepositoryAsync;
            }
            public async Task<Response<RoleGroup>> Handle(UpdateRoleGroupCommand request, CancellationToken cancellationToken)
            {
                var _RoleGroupToUpdate = new RoleGroup()
                {
                    Id = request.roleGroupToUpdate.Id,
                    CustomerApplicationId = request.roleGroupToUpdate.CustomerApplicationId,
                    Name = request.roleGroupToUpdate.Name,
                    Description = request.roleGroupToUpdate.Description
                };

                var _RoleGroupToUpdateResponse = await _roleGroupRepositoryAsync.UpdateRoleGroupAsync(_RoleGroupToUpdate);

                if (_RoleGroupToUpdateResponse.Id == 0)
                {
                    return new Response<RoleGroup>()
                    {
                        Succeeded = false,
                        Message = $"Role Group not found to update",
                        Data = null
                    };
                }

                return new Response<RoleGroup>()
                {
                    Succeeded = true,
                    Message = $"Role Group updated successfully",
                    Data = _RoleGroupToUpdateResponse
                };

            }
        }
    }
}

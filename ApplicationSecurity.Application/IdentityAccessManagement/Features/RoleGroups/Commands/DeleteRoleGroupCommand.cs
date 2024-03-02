using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.RoleGroups.Commands
{
    public class DeleteRoleGroupCommand : IRequest<Response<RoleGroup>>
    {
        public int RoleGroupId { get; set; }
        public class DeleteRoleGroupCommandHandler : IRequestHandler<DeleteRoleGroupCommand, Response<RoleGroup>>
        {
            private readonly IRoleGroupRepositoryAsync _roleGroupRepositoryAsync;
            public DeleteRoleGroupCommandHandler(IRoleGroupRepositoryAsync _roleGroupRepositoryAsync)
            {
                this._roleGroupRepositoryAsync = _roleGroupRepositoryAsync;
            }
            public async Task<Response<RoleGroup>> Handle(DeleteRoleGroupCommand request, CancellationToken cancellationToken)
            {
                var RoleGroupToMakeInactive = new RoleGroup { Id = request.RoleGroupId };

                var RoleGroupToMakeInactiveResponse = await _roleGroupRepositoryAsync.DeleteRoleGroupAsync(RoleGroupToMakeInactive);

                if (RoleGroupToMakeInactiveResponse.Id == 0)
                {
                    return new Response<RoleGroup>()
                    {
                        Succeeded = false,
                        Message = $"Role Group not found to make inactive",
                        Data = null
                    };
                }

                return new Response<RoleGroup>()
                {
                    Succeeded = true,
                    Message = $"Role Group is now inactive",
                    Data = RoleGroupToMakeInactiveResponse
                };

            }
        }
    }
}

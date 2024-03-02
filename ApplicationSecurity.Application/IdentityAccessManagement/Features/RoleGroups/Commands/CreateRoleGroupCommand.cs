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
    public class CreateRoleGroupCommand : IRequest<Response<RoleGroup>>
    {
        public RoleGroupModel RoleGroupToCreate { get; set; }
        public class CreateRoleGroupCommandHandler : IRequestHandler<CreateRoleGroupCommand, Response<RoleGroup>>
        {
            private readonly IRoleGroupRepositoryAsync _roleGroupRepositoryAsync;
            public CreateRoleGroupCommandHandler(IRoleGroupRepositoryAsync _roleGroupRepositoryAsync)
            {
                this._roleGroupRepositoryAsync = _roleGroupRepositoryAsync;
            }
            public async Task<Response<RoleGroup>> Handle(CreateRoleGroupCommand request, CancellationToken cancellationToken)
            {
                var _roleGroupToAdd = new RoleGroup()
                {
                    CustomerApplicationId = request.RoleGroupToCreate.CustomerApplicationId,
                    Name = request.RoleGroupToCreate.Name,
                    Description = request.RoleGroupToCreate.Description,
                    ActiveFlag = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                var createdRoleGroup = await _roleGroupRepositoryAsync.AddRoleGroupAsync(_roleGroupToAdd);

                return new Response<RoleGroup>()
                {
                    Succeeded = true,
                    Message = "Role Group created successfully",
                    Data = createdRoleGroup
                };
            }
        }
    }
}

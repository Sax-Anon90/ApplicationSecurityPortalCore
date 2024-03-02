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
    public class CreateRoleCommand : IRequest<Response<Role>>
    {
        public RoleModel roleToAdd { get; set; }

        public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Response<Role>>
        {
            private readonly IRoleRepositoryAsync _roleRepositoryAsync;
            public CreateRoleCommandHandler(IRoleRepositoryAsync _roleRepositoryAsync)
            {
                this._roleRepositoryAsync = _roleRepositoryAsync;
            }
            public async Task<Response<Role>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                var _roleToAdd = new Role()
                {
                    RoleGroupId = request.roleToAdd.RoleGroupId,
                    Name = request.roleToAdd.Name,
                    Description = request.roleToAdd.Description,
                    ActiveFlag = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                };

                var createdRole = await _roleRepositoryAsync.AddRoleAsync(_roleToAdd);

                return new Response<Role>()
                {
                    Succeeded = true,
                    Message = "Role created successfully",
                    Data = createdRole
                };
            }
        }
    }
}

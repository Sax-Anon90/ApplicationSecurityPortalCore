using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Roles;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Roles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.Roles.Queries
{
    public class GetRoleByIdQuery : IRequest<Response<RolesViewModel>>
    {
        public int Roleid { get; set; }
        public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Response<RolesViewModel>>
        {
            private readonly IRoleRepositoryAsync _roleRepositoryAsync;
            public GetRoleByIdQueryHandler(IRoleRepositoryAsync _roleRepositoryAsync)
            {
                this._roleRepositoryAsync = _roleRepositoryAsync;
            }
            public async Task<Response<RolesViewModel>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
            {
                var _role = await _roleRepositoryAsync.GetRoleByRoleIdAsync(request.Roleid);

                if (_role.Id == null)
                {
                    return new Response<RolesViewModel>
                    {
                        Succeeded = false,
                        Message = $"Role not found to update",
                        Data = null
                    };
                }

                return new Response<RolesViewModel>
                {
                    Succeeded = true,
                    Message = $"Role found successfully",
                    Data = _role
                };
            }
        }
    }
}

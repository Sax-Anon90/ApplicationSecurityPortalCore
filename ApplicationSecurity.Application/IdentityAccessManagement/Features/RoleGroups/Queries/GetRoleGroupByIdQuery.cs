using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.RoleGroups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.RoleGroups.Queries
{
    public class GetRoleGroupByIdQuery : IRequest<Response<RoleGroupViewModel>>
    {
        public int RoleGroupId { get; set; }
        public class GetRoleGroupByIdQueryHandler : IRequestHandler<GetRoleGroupByIdQuery, Response<RoleGroupViewModel>>
        {
            private readonly IRoleGroupRepositoryAsync _roleGroupRepositoryAsync;
            public GetRoleGroupByIdQueryHandler(IRoleGroupRepositoryAsync _roleGroupRepositoryAsync)
            {
                this._roleGroupRepositoryAsync = _roleGroupRepositoryAsync;
            }
            public async Task<Response<RoleGroupViewModel>> Handle(GetRoleGroupByIdQuery request, CancellationToken cancellationToken)
            {
                var _roleGroup = await _roleGroupRepositoryAsync.GetRoleGroupByRoleGroupIdAsync(request.RoleGroupId);

                if (_roleGroup.Id == null)
                {
                    return new Response<RoleGroupViewModel>()
                    {
                        Succeeded = false,
                        Message = $"Role group not found",
                        Data = null
                    };
                }

                return new Response<RoleGroupViewModel>()
                {
                    Succeeded = true,
                    Message = $"Role group retreived successfully",
                    Data = _roleGroup
                };

            }
        }
    }
}

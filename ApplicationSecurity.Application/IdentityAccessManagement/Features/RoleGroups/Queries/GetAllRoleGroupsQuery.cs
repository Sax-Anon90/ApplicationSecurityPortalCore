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
    public record GetAllRoleGroupsQuery : IRequest<Response<IEnumerable<RoleGroupViewModel>>>;
    public class GetAllRoleGroupsQueryHandler : IRequestHandler<GetAllRoleGroupsQuery, Response<IEnumerable<RoleGroupViewModel>>>
    {
        private readonly IRoleGroupRepositoryAsync _roleGroupRepositoryAsync;
        public GetAllRoleGroupsQueryHandler(IRoleGroupRepositoryAsync _roleGroupRepositoryAsync)
        {
            this._roleGroupRepositoryAsync = _roleGroupRepositoryAsync;
        }
        public async Task<Response<IEnumerable<RoleGroupViewModel>>> Handle(GetAllRoleGroupsQuery request, CancellationToken cancellationToken)
        {
            var _roleGroups = await _roleGroupRepositoryAsync.GetAllRoleGroupsAsync();

            if (_roleGroups.Count() == 0)
            {
                return new Response<IEnumerable<RoleGroupViewModel>>()
                {
                    Succeeded = true,
                    Message = "No Role Groups have been found",
                    Data = Enumerable.Empty<RoleGroupViewModel>()
                };
            }

            return new Response<IEnumerable<RoleGroupViewModel>>()
            {
                Succeeded = true,
                Message = "RoleGroups retreived successfully",
                Data = _roleGroups
            };
        }
    }

}

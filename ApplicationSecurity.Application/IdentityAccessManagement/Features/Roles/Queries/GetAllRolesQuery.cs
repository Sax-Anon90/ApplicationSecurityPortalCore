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
    public record GetAllRolesQuery : IRequest<Response<IEnumerable<RolesViewModel>>>;
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, Response<IEnumerable<RolesViewModel>>>
    {
        private readonly IRoleRepositoryAsync _roleRepositoryAsync;
        public GetAllRolesQueryHandler(IRoleRepositoryAsync _roleRepositoryAsync)
        {
            this._roleRepositoryAsync = _roleRepositoryAsync;
        }
        public async Task<Response<IEnumerable<RolesViewModel>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var _roles = await _roleRepositoryAsync.GetAllRolesAsync();

            if (_roles.Count() == 0)
            {
                return new Response<IEnumerable<RolesViewModel>>()
                {
                    Succeeded = true,
                    Message = "No Roles have been found",
                    Data = Enumerable.Empty<RolesViewModel>()
                };
            }

            return new Response<IEnumerable<RolesViewModel>>()
            {
                Succeeded = true,
                Message = "Roles retreived successfully",
                Data = _roles
            };
        }
    }

}

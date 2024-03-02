using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.UserRoles.Queries
{
    public class GetUserRolesByUserIdQuery : IRequest<Response<IEnumerable<UserRolesViewModel>>>
    {
        public int UserId { get; set; }
        public class GetUserRolesByUserIdQueryHandler : IRequestHandler<GetUserRolesByUserIdQuery, Response<IEnumerable<UserRolesViewModel>>>
        {
            private readonly IUserRoleRepositoryAsync _userRoleRepositoryAsync;
            public GetUserRolesByUserIdQueryHandler(IUserRoleRepositoryAsync _userRoleRepositoryAsync)
            {
                this._userRoleRepositoryAsync = _userRoleRepositoryAsync;
            }
            public async Task<Response<IEnumerable<UserRolesViewModel>>> Handle(GetUserRolesByUserIdQuery request, CancellationToken cancellationToken)
            {
                var _userRoles = await _userRoleRepositoryAsync.GetAllUserRolesByUserIdAsync(request.UserId);

                if (_userRoles.Count() == 0)
                {
                    return new Response<IEnumerable<UserRolesViewModel>>
                    {
                        Succeeded = true,
                        Message = $"No user Roles found",
                        Data = Enumerable.Empty<UserRolesViewModel>()
                    };
                }

                return new Response<IEnumerable<UserRolesViewModel>>
                {
                    Succeeded = true,
                    Message = $"User Roles found successfully",
                    Data = _userRoles
                };
            }
        }
    }
}

using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Users;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.Users.Queries
{
    public class GetUserByUserIdQuery : IRequest<Response<UsersViewModel>>
    {
        public int UserId { get; set; }
        public class GetUserByUserIdQueryHandler : IRequestHandler<GetUserByUserIdQuery, Response<UsersViewModel>>
        {
            private readonly IUsersRepositoryAsync _usersRepositoryAsync;
            public GetUserByUserIdQueryHandler(IUsersRepositoryAsync _usersRepositoryAsync)
            {
                this._usersRepositoryAsync = _usersRepositoryAsync;
            }
            public async Task<Response<UsersViewModel>> Handle(GetUserByUserIdQuery request, CancellationToken cancellationToken)
            {
                var _user = await _usersRepositoryAsync.GetUserByUserIdAsync(request.UserId);

                if (_user.Id == null)
                {
                    return new Response<UsersViewModel>()
                    {
                        Succeeded = false,
                        Message = $"User not found",
                        Data = null
                    };
                }

                return new Response<UsersViewModel>()
                {
                    Succeeded = true,
                    Message = $"User retreived successfully",
                    Data = _user
                };
            }
        }
    }
}

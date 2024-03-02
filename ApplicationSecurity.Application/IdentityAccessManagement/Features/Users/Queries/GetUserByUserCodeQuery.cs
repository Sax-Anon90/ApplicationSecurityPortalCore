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
    public class GetUserByUserCodeQuery : IRequest<Response<UsersViewModel>>
    {
        public string UserCode { get; set; }
        public class GetUserByUserCodeQueryHandler : IRequestHandler<GetUserByUserCodeQuery, Response<UsersViewModel>>
        {
            private readonly IUsersRepositoryAsync _usersRepositoryAsync;
            public GetUserByUserCodeQueryHandler(IUsersRepositoryAsync _usersRepositoryAsync)
            {
                this._usersRepositoryAsync = _usersRepositoryAsync;
            }
            public async Task<Response<UsersViewModel>> Handle(GetUserByUserCodeQuery request, CancellationToken cancellationToken)
            {
                var _user = await _usersRepositoryAsync.GetUserByUserCodeAsync(request.UserCode);

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

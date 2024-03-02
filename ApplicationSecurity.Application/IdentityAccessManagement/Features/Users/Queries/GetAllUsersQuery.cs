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
    public record GetAllUsersQuery : IRequest<Response<IEnumerable<UsersViewModel>>>;
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IEnumerable<UsersViewModel>>>
    {
        private readonly IUsersRepositoryAsync _usersRepository;
        public GetAllUsersQueryHandler(IUsersRepositoryAsync _usersRepository)
        {
            this._usersRepository = _usersRepository;
        }
        public async Task<Response<IEnumerable<UsersViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _usersRepository.GetAllUsersAsync();

            if (users.Count() == 0)
            {
                return new Response<IEnumerable<UsersViewModel>>()
                {
                    Succeeded = true,
                    Message = "No Users have been found",
                    Data = Enumerable.Empty<UsersViewModel>()
                };
            }

            return new Response<IEnumerable<UsersViewModel>>()
            {
                Succeeded = true,
                Message = "Users retreived successfully",
                Data = users
            };
        }
    }

}

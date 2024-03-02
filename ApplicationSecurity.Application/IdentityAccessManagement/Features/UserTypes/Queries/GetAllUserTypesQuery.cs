using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.UserTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.UserTypes.Queries
{
    public record GetAllUserTypesQuery : IRequest<Response<IEnumerable<UserTypesViewModel>>>;
    public class GetAllUserTypesQueryHandler : IRequestHandler<GetAllUserTypesQuery, Response<IEnumerable<UserTypesViewModel>>>
    {
        private readonly IUserTypesRepositoryAsync _userTypesRepositoryAsync;
        public GetAllUserTypesQueryHandler(IUserTypesRepositoryAsync _userTypesRepositoryAsync)
        {
            this._userTypesRepositoryAsync = _userTypesRepositoryAsync;
        }
        public async Task<Response<IEnumerable<UserTypesViewModel>>> Handle(GetAllUserTypesQuery request, CancellationToken cancellationToken)
        {
            var _userTypes = await _userTypesRepositoryAsync.GetAllUserTypesAsync();

            if (_userTypes.Count() == 0)
            {
                return new Response<IEnumerable<UserTypesViewModel>>()
                {
                    Succeeded = true,
                    Message = "No User Types have been found",
                    Data = Enumerable.Empty<UserTypesViewModel>()
                };
            }

            return new Response<IEnumerable<UserTypesViewModel>>()
            {
                Succeeded = true,
                Message = "User Types found successfully",
                Data = _userTypes
            };
        }
    }
}

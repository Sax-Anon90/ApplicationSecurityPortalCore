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
    public class GetUserTypeByUserTypeIdQuery : IRequest<Response<UserTypesViewModel>>
    {
        public int UserTypeId { get; set; }
        public class GetUserTypeByUserTypeIdQueryHandler : IRequestHandler<GetUserTypeByUserTypeIdQuery, Response<UserTypesViewModel>>
        {
            private readonly IUserTypesRepositoryAsync _userTypesRepositoryAsync;
            public GetUserTypeByUserTypeIdQueryHandler(IUserTypesRepositoryAsync _userTypesRepositoryAsync)
            {
                this._userTypesRepositoryAsync = _userTypesRepositoryAsync;
            }
            public async Task<Response<UserTypesViewModel>> Handle(GetUserTypeByUserTypeIdQuery request, CancellationToken cancellationToken)
            {
                var _userType = await _userTypesRepositoryAsync.GetUserTypeByUserTypeId(request.UserTypeId);

                if (_userType.Id == null)
                {
                    return new Response<UserTypesViewModel>()
                    {
                        Succeeded = false,
                        Message = $"User Type not found",
                        Data = null
                    };
                }

                return new Response<UserTypesViewModel>()
                {
                    Succeeded = true,
                    Message = $"User Type retreived successfully",
                    Data = _userType
                };
            }
        }

    }
}

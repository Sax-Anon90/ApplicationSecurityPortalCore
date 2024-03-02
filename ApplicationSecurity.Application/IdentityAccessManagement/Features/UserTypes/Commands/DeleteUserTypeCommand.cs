using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.UserTypes.Commands
{
    public class DeleteUserTypeCommand : IRequest<Response<UserType>>
    {
        public int UserTypeId { get; set; }

        public class DeleteUserTypeCommandHandler : IRequestHandler<DeleteUserTypeCommand, Response<UserType>>
        {
            private readonly IUserTypesRepositoryAsync _userTypesRepositoryAsync;
            public DeleteUserTypeCommandHandler(IUserTypesRepositoryAsync _userTypesRepositoryAsync)
            {
                this._userTypesRepositoryAsync = _userTypesRepositoryAsync;
            }
            public async Task<Response<UserType>> Handle(DeleteUserTypeCommand request, CancellationToken cancellationToken)
            {
                var _userTypeToMakeInactive = new UserType() { Id = request.UserTypeId };

                var _userTypeToMakeInactiveResponse = await _userTypesRepositoryAsync.DeleteUserTypeAsync(_userTypeToMakeInactive);

                if (_userTypeToMakeInactiveResponse.Id == 0)
                {
                    return new Response<UserType>()
                    {
                        Succeeded = false,
                        Message = $"User Type not found to make inactive",
                        Data = null
                    };
                }

                return new Response<UserType>()
                {
                    Succeeded = true,
                    Message = $"Customer for application is now Inactive",
                    Data = _userTypeToMakeInactiveResponse
                };
            }
        }
    }
}

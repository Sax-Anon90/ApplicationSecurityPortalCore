using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes;
using ApplicationSecurity.Application.ReusableClasses;
using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.UserTypes;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.Features.UserTypes.Commands
{
    public class UpdateUserTypeCommand : IRequest<Response<UserType>>
    {
        public UpdateUserTypesModel userTypeToUpdate { get; set; }

        public class UpdateUserTypeCommandHandler : IRequestHandler<UpdateUserTypeCommand, Response<UserType>>
        {
            private readonly IUserTypesRepositoryAsync _userTypesRepositoryAsync;
            public UpdateUserTypeCommandHandler(IUserTypesRepositoryAsync _userTypesRepositoryAsync)
            {
                this._userTypesRepositoryAsync = _userTypesRepositoryAsync;
            }
            public async Task<Response<UserType>> Handle(UpdateUserTypeCommand request, CancellationToken cancellationToken)
            {
                var _userTypeToUpdate = new UserType()
                {
                    Id = request.userTypeToUpdate.Id,
                    Name = request.userTypeToUpdate.Name,
                    Description = request.userTypeToUpdate.Description,
                };

                var _userTypeToUpdateResponse = await _userTypesRepositoryAsync.UpdateUserTypeAsync(_userTypeToUpdate);

                if (_userTypeToUpdateResponse.Id == 0)
                {
                    return new Response<UserType>()
                    {
                        Succeeded = false,
                        Message = $"User Type not found to update",
                        Data = null
                    };
                }

                return new Response<UserType>()
                {
                    Succeeded = true,
                    Message = $"User Type updated successfully",
                    Data = _userTypeToUpdateResponse
                };
            }
        }
    }
}

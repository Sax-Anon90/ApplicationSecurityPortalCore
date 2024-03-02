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
    public class CreateUserTypeCommand : IRequest<Response<UserType>>
    {
        public UserTypeModel userTypeToCreate { get; set; }
        public class CreateCustomerForApplicationCommandHandler : IRequestHandler<CreateUserTypeCommand, Response<UserType>>
        {
            private readonly IUserTypesRepositoryAsync _userTypesRepositoryAsync;
            public CreateCustomerForApplicationCommandHandler(IUserTypesRepositoryAsync _userTypesRepositoryAsync)
            {
                this._userTypesRepositoryAsync = _userTypesRepositoryAsync;
            }
            public async Task<Response<UserType>> Handle(CreateUserTypeCommand request, CancellationToken cancellationToken)
            {
                var _userTypeToCreate = new UserType()
                {
                    Name = request.userTypeToCreate.Name,
                    Description = request.userTypeToCreate.Description,
                    ActiveFlag = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                };

                var createdUserType = await _userTypesRepositoryAsync.AddUserTypeAsync(_userTypeToCreate);

                return new Response<UserType>()
                {
                    Succeeded = true,
                    Message = "User Type created successfully",
                    Data = createdUserType
                };
            }
        }
    }
}

using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes
{
    public interface IUserTypesServiceAsync
    {
        Task<Response<IEnumerable<UserTypesViewModel>>> GetAllUserTypesAsync();
        Task<Response<UserTypesViewModel>> CreateUserTypeAsync(UserTypesInputModel userTypesInputModel);
        Task<Response<UserTypesViewModel>> UpdateUserTypesAsync(UserTypesUpdateModel userTypesUpdateModel);
        Task<Response<UserTypesViewModel>> DeleteUserTypesAsync(int UserTypeId);
    }
}

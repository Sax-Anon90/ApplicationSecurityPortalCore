using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.UserTypes;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes
{
    public interface IUserTypesRepositoryAsync
    {
        Task<UserTypesViewModel> GetUserTypeByUserTypeId(int UserTypeId);
        Task<IEnumerable<UserTypesViewModel>> GetAllUserTypesAsync();
        Task<UserType> AddUserTypeAsync(UserType userTypeToAdd);
        Task<UserType> UpdateUserTypeAsync(UserType userTypeToUpdate);
        Task<UserType> DeleteUserTypeAsync(UserType userTypeToRemove);
    }
}

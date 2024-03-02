using ApplicationSecurity.Domain.IdentityAccessManagement.InputModel.Users;
using ApplicationSecurity.Domain.IdentityAccessManagement.ViewModelDTOs.Users;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Users
{
    public interface IUsersRepositoryAsync
    {
        Task<UsersViewModel> GetUserByUserIdAsync(int userId);
        Task<IEnumerable<UsersViewModel>> GetAllUsersAsync();

        Task<UsersViewModel> GetUserByUserCodeAsync(string UserCode);
        Task<User> AddUserAsync(User userToAdd);
        Task<User> UpdateUserAsync(User userToUpdate);
        Task<User> DeleteUserAsync(User UserToRemove);
        Task<User> GetUserByEmailAsync(string email);

    }
}

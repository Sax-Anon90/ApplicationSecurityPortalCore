using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.Users;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.Users;
using ApplicationSecurityPortal.Infrustructure.BaseApiService;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.Users
{
    public class UsersServiceAsync : IUsersServiceAsync
    {
        private readonly ApiService _apiService;
        public UsersServiceAsync(ApiService _apiService)
        {
            this._apiService = _apiService;
        }
        public async Task<Response<UsersViewModel>> CreateUserAsync(UsersInputModel usersInputModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UsersEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                   .PostJsonAsync(new
                                                                   {
                                                                       UserToAdd = usersInputModel
                                                                   })
                                                                   .ReceiveJson<Response<UsersViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<UsersViewModel>> DeleteUserAsync(int UserId)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UsersEndpoint}{UserId}")
                                                                    .AllowAnyHttpStatus()
                                                                    .DeleteAsync()
                                                                    .ReceiveJson<Response<UsersViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<IEnumerable<UsersViewModel>>> GetAllUsersAsync()
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UsersEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                   .GetJsonAsync<Response<IEnumerable<UsersViewModel>>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<IEnumerable<UsersViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<IEnumerable<UsersViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<UsersViewModel>>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<UsersViewModel>> GetUserByUserCodeAsync(string UserCode)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UsersEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                   .GetJsonAsync<Response<UsersViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<UsersViewModel>> GetUserByUserIdAsync(int UserId)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UsersEndpoint}{UserId}")
                                                                   .AllowAnyHttpStatus()
                                                                   .GetJsonAsync<Response<UsersViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<UsersViewModel>> UpdateUserAsync(UsersUpdateModel usersUpdateModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UsersEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                   .PutJsonAsync(new
                                                                   {
                                                                       userToUpdate = usersUpdateModel
                                                                   })
                                                                   .ReceiveJson<Response<UsersViewModel>>();
                return response;

            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<UsersViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }
    }
}

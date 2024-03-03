using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.UserTypes;
using ApplicationSecurityPortal.Infrustructure.BaseApiService;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.UserTypes
{
    public class UserTypesServiceAsync : IUserTypesServiceAsync
    {
        private readonly ApiService _apiService;
        public UserTypesServiceAsync(ApiService _apiService)
        {
            this._apiService = _apiService;
        }
        public async Task<Response<UserTypesViewModel>> CreateUserTypeAsync(UserTypesInputModel userTypesInputModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UserTypesEndpoint}")
                                                                    .AllowAnyHttpStatus()
                                                                    .PostJsonAsync(new
                                                                    {
                                                                        userTypeToCreate = userTypesInputModel
                                                                    })
                                                                    .ReceiveJson<Response<UserTypesViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<UserTypesViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<UserTypesViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<UserTypesViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<UserTypesViewModel>> DeleteUserTypesAsync(int UserTypeId)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UserTypesEndpoint}{UserTypeId}")
                                                                    .AllowAnyHttpStatus()
                                                                    .DeleteAsync()
                                                                    .ReceiveJson<Response<UserTypesViewModel>>();
                return response;

            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<UserTypesViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<UserTypesViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<UserTypesViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<IEnumerable<UserTypesViewModel>>> GetAllUserTypesAsync()
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UserTypesEndpoint}")
                                                                    .AllowAnyHttpStatus()
                                                                    .GetJsonAsync<Response<IEnumerable<UserTypesViewModel>>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<IEnumerable<UserTypesViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<IEnumerable<UserTypesViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<UserTypesViewModel>>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<UserTypesViewModel>> UpdateUserTypesAsync(UserTypesUpdateModel userTypesUpdateModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.UserTypesEndpoint}")
                                                                    .AllowAnyHttpStatus()
                                                                    .PutJsonAsync(new
                                                                    {
                                                                        userTypeToUpdate = userTypesUpdateModel
                                                                    })
                                                                    .ReceiveJson<Response<UserTypesViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<UserTypesViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<UserTypesViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<UserTypesViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }
    }
}

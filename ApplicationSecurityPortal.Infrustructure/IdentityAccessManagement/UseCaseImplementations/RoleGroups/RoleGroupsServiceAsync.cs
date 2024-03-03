using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.RoleGroups;
using ApplicationSecurityPortal.Infrustructure.BaseApiService;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.RoleGroups
{
    public class RoleGroupsServiceAsync : IRoleGroupsServiceAsync
    {
        private readonly ApiService _apiService;
        public RoleGroupsServiceAsync(ApiService _apiService)
        {
            this._apiService = _apiService;
        }
        public async Task<Response<RoleGroupsViewModel>> CreateRoleGroupAsync(RoleGroupsInputModel roleGroupsInputModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.RoleGroupsEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                   .PostJsonAsync(new
                                                                   {
                                                                       RoleGroupToCreate = roleGroupsInputModel
                                                                   })
                                                                   .ReceiveJson<Response<RoleGroupsViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<RoleGroupsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<RoleGroupsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<RoleGroupsViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<RoleGroupsViewModel>> DeleteRoleGroupAsync(int RoleGroupId)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.RoleGroupsEndpoint}{RoleGroupId}")
                                                                   .AllowAnyHttpStatus()
                                                                   .DeleteAsync()
                                                                   .ReceiveJson<Response<RoleGroupsViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<RoleGroupsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<RoleGroupsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<RoleGroupsViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<IEnumerable<RoleGroupsViewModel>>> GetAllRoleGroupsAsync()
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.RoleGroupsEndpoint}")
                                                                  .AllowAnyHttpStatus()
                                                                  .GetJsonAsync<Response<IEnumerable<RoleGroupsViewModel>>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<IEnumerable<RoleGroupsViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<IEnumerable<RoleGroupsViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<RoleGroupsViewModel>>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<RoleGroupsViewModel>> UpdateRoleGroupAsync(RoleGroupsUpdateModel roleGroupsUpdateModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.RoleGroupsEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                   .PutJsonAsync(new
                                                                   {
                                                                       roleGroupToUpdate = roleGroupsUpdateModel
                                                                   })
                                                                   .ReceiveJson<Response<RoleGroupsViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<RoleGroupsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<RoleGroupsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<RoleGroupsViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }
    }
}
